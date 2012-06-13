using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ENT = HP.SW.SWT.Entities;
using HP.SW.SWT.Extensions;

namespace HP.SW.SWT.Data
{
    public class ADResourceAssignment : ADBase
    {
        private static ENT.ResourceAssignment Get(ResourceAssignment dbResourceAssignment, ENT.Period period)
        {
            ENT.ResourceAssignment resourceAssignment = null;
            if (dbResourceAssignment != null)
            {
                resourceAssignment = new ENT.ResourceAssignment
                {
                    ID = dbResourceAssignment.IdrEsourceAssignment,
                    Period = period ?? Data.ADPeriod.Get(dbResourceAssignment.IdpEriod),
                    Resource = Data.ADResource.Get(dbResourceAssignment.T)
                };

                IEnumerable<ENT.ResourceAssignmentDay> exceptions = (from rae in Context.ResourceAssignmentException
                                                                     where rae.IdrEsourceAssignment == resourceAssignment.ID
                                                                     select new ENT.ResourceAssignmentDay
                                                                     {
                                                                         Date = rae.Date,
                                                                         Hours = rae.HoursInDay
                                                                     });

                List<ENT.ResourceAssignmentDay> days = new List<ENT.ResourceAssignmentDay>();
                ENT.ResourceAssignmentDay exception;
                for (DateTime d = resourceAssignment.Period.StartDate.Date; d <= resourceAssignment.Period.EndDate.Value.Date; d = d.AddDays(1))
                {
                    exception = exceptions.Where(e => e.Date == d).FirstOrDefault();

                    if (exception == null)
                    {
                        if (ENT.DateHelper.IsWorkingDay(d))
                        {
                            days.Add(new ENT.ResourceAssignmentDay { Date = d, Hours = dbResourceAssignment.HoursPerDay });
                        }
                        else
                        {
                            days.Add(new ENT.ResourceAssignmentDay { Date = d, Hours = 0 });
                        }
                    }
                    else
                    {
                        days.Add(exception);
                    }
                }
                resourceAssignment.Days = days;
            }

            return resourceAssignment;
        }

        public static ENT.ResourceAssignment Get(int id)
        {
            return Get((from ra in Context.ResourceAssignment
                        where ra.IdrEsourceAssignment == id
                        select ra).FirstOrDefault(), null);
        }

        public static ENT.ResourceAssignment Get(ENT.Resource resource, ENT.Period period)
        {
            if (!period.EndDate.HasValue)
            {
                throw new Exception("No se puede pedir el estimado mensual para un período en el que no se sabe la fecha de fin.");
            }

            return Get((from ra in Context.ResourceAssignment
                        where ra.T == resource.T && ra.IdpEriod == period.ID
                        select ra).FirstOrDefault(), period);
        }

        public static IEnumerable<ENT.ResourceAssignment> Get(ENT.Period period)
        {
            return (from ra in Context.ResourceAssignment
                    where ra.IdpEriod == period.ID
                    select ra).ToList().ConvertAll(ra => Get(ra, period));
        }

        public static decimal GetMonthlyHoursInitial(ENT.Period period)
        {
            var assignments = (from ra in Context.ResourceAssignment
                               where ra.IdpEriod == period.ID
                               select ra.HoursPerDay);

            if (assignments.Count() == 0)
            {
                return 0;
            }
            else
            {
                return assignments.Sum() * period.BusinessDays;
            }
        }

        public static decimal GetScheduledAbsences(ENT.Period period)
        {
            decimal res = 0;
            foreach (ResourceAssignment resourceAssignment in (from ra in Context.ResourceAssignment
                                                               where ra.IdpEriod == period.ID
                                                               select ra))
            {
                res += (from rae in Context.ResourceAssignmentException
                        where rae.IdrEsourceAssignment == resourceAssignment.IdrEsourceAssignment && resourceAssignment.HoursPerDay > rae.HoursInDay
                        select resourceAssignment.HoursPerDay - rae.HoursInDay).SumOrZero();
            }
            return res;
        }
    }
}