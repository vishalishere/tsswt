using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADPeriod : ADBase
    {
        public static IEnumerable<ENT.Period> GetPeriods(int year)
        {
            return from p in Context.Period
                   where p.Year == year
                   select new ENT.Period
                            {
                                Year = p.Year,
                                Month = p.Month,
                                StartDate = p.StartDate,
                                EndDate = p.EndDate
                            };

            //return Context.Period.ToList().ConvertAll<ENT.Period>(delegate(Period p) {
            //    return new ENT.Period
            //       {
            //           Year = p.Year,
            //           Month = p.Month,
            //           StartDate = p.StartDate,
            //           EndDate = p.EndDate
            //       };
            //});
        }

        public static ENT.Period GetCurrentPeriod()
        {
            DateTime now = DateTime.Now.Date;

            return (from p in GetPeriods(now.Year)
                    where p.StartDate.CompareTo(now) <= 0
                         && (!p.EndDate.HasValue || p.EndDate.Value.CompareTo(now) >= 0)
                    select new ENT.Period
                    {
                        Year = p.Year,
                        Month = p.Month,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate
                    }).FirstOrDefault();

        }
    }
}