using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADResourceAssignment : ADBase
    {
        public static ENT.ResourceAssignment Get(int id)
        {
            return (from ra in Context.ResourceAssignment
                    where ra.IdrEsourceAssignment == id
                    select new ENT.ResourceAssignment
                    {
                        ID = ra.IdrEsourceAssignment,
                        Resource = ADResource.Get(ra.T),
                        Period = ADPeriod.Get(ra.IdpEriod),
                        HoursPerDay = ra.HoursPerDay
                    }).FirstOrDefault();
        }

        public static ENT.ResourceAssignment Get(ENT.Resource resource, ENT.Period period)
        {
            ENT.ResourceAssignment resourceAssignment = (from ra in Context.ResourceAssignment
                                                         where ra.T == resource.T && ra.IdpEriod == period.ID
                                                         select new ENT.ResourceAssignment
                                                         {
                                                             ID = ra.IdrEsourceAssignment,
                                                             //Resource = resource,
                                                             //Period = period,
                                                             HoursPerDay = ra.HoursPerDay
                                                         }).FirstOrDefault();

            if (resourceAssignment != null)
            {
                resourceAssignment.Resource = resource;
                resourceAssignment.Period = period;
            }

            return resourceAssignment;
        }

        private static IEnumerable<ENT.ResourceAssignmentDay> GetMonthlyHoursEstimated(ENT.Resource resource, ENT.Period period, ENT.ResourceAssignment ra)
        {
            if (!period.EndDate.HasValue)
            {
                throw new Exception("No se puede pedir el estimado mensual para un período en el que no se sabe la fecha de fin.");
            }

            List<ENT.ResourceAssignmentDay> res = new List<ENT.ResourceAssignmentDay>();
            for (DateTime d = period.StartDate.Date; d <= period.EndDate.Value.Date; d = d.AddDays(1))
            {
                if (ENT.DateHelper.IsWorkingDay(d))
                {
                    res.Add(new ENT.ResourceAssignmentDay { ID = -1, Resource = resource, Date = d, HoursPerDay = ra.HoursPerDay });
                }
                else
                {
                    res.Add(new ENT.ResourceAssignmentDay { ID = -1, Resource = resource, Date = d, HoursPerDay = 0 });
                }
            }
            return res;
        }

        public static IEnumerable<ENT.ResourceAssignmentDay> GetMonthlyHoursEstimated(ENT.Resource resource, ENT.Period period)
        {
            ENT.ResourceAssignment ra = Data.ADResourceAssignment.Get(resource, period);

            if (ra == null)
            {
                return null;
            }

            return GetMonthlyHoursEstimated(resource, period, ra);
        }

        public static IEnumerable<ENT.ResourceAssignmentDay> GetMonthlyHoursReal(ENT.Resource resource, ENT.Period period)
        {
            ENT.ResourceAssignment ra = Data.ADResourceAssignment.Get(resource, period);

            if (ra == null)
            {
                return null;
            }
            IEnumerable<ENT.ResourceAssignmentDay> res = Data.ADResourceAssignment.GetMonthlyHoursEstimated(resource, period, ra);
            IEnumerable<Data.ResourceAssignmentException> exceptions = (from rae in Context.ResourceAssignmentException
                                                                        where rae.IdrEsourceAssignment == ra.ID
                                                                        select rae);

            Data.ResourceAssignmentException exception;
            foreach (ENT.ResourceAssignmentDay day in res)
            {
                exception = exceptions.Where(rae => rae.Date.Date == day.Date.Date).FirstOrDefault();

                if (exception != null)
                {
                    day.HoursPerDay = exception.HoursInDay;
                }
            }
            return res;
        }
    }
}
