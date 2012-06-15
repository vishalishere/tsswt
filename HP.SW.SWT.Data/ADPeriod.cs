using System;
using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADPeriod : ADBase
    {
        #region Gets
        public static IEnumerable<ENT.Period> GetPeriods(int year)
        {
            return from p in Context.Period
                   where p.Year == year
                   select new ENT.Period
                            {
                                ID = p.IdpEriod,
                                Description = p.Description,
                                Year = p.Year,
                                Month = p.Month,
                                StartDate = p.StartDate,
                                EndDate = p.EndDate
                            };
        }

        public static ENT.Period Get(DateTime dateTime)
        {
            return (from p in GetPeriods(dateTime.Year)
                    where p.StartDate.CompareTo(dateTime) <= 0
                         && (!p.EndDate.HasValue || p.EndDate.Value.CompareTo(dateTime) >= 0)
                    select new ENT.Period
                    {
                        ID = p.ID,
                        Description = p.Description,
                        Year = p.Year,
                        Month = p.Month,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate
                    }).FirstOrDefault();
        }

        public static ENT.Period GetCurrentPeriod()
        {
            return Get(DateTime.Now.Date);
        }

        public static IEnumerable<ENT.Period> GetAll()
        {
            return from p in Context.Period
                   select new ENT.Period
                   {
                       ID = p.IdpEriod,
                       Description = p.Description,
                       Year = p.Year,
                       Month = p.Month,
                       StartDate = p.StartDate,
                       EndDate = p.EndDate
                   };
        }

        public static ENT.Period Get(int id)
        {
            return (from p in Context.Period
                    where p.IdpEriod == id
                    select new ENT.Period
                    {
                        ID = p.IdpEriod,
                        Description = p.Description,
                        Year = p.Year,
                        Month = p.Month,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate
                    }).FirstOrDefault();
        } 
        #endregion

        public static void Insert(ENT.Period period)
        {
            using (SwT ctx = Context)
            {
                Data.Period p = new Period
                {
                    Description = period.Description,
                    EndDate = period.EndDate,
                    IdpEriod = period.ID,
                    Month = period.Month,
                    StartDate = period.StartDate,
                    Year = period.Year                          
                };

                ctx.Period.InsertOnSubmit(p);
                ctx.SubmitChanges();
            }
        }

        public static void Update(int id, ENT.Period period)
        {
            using (SwT ctx = Context)
            {
                Period dataPeriod = (from p in ctx.Period
                                     where p.IdpEriod == id
                                     select p).FirstOrDefault();
                
                dataPeriod.Description = period.Description;
                dataPeriod.EndDate = period.EndDate;                
                dataPeriod.Month = period.Month;
                dataPeriod.StartDate = period.StartDate;
                dataPeriod.Year = period.Year;

                ctx.SubmitChanges();
            }
        }

        public static void Delete(int id)
        {
            using (SwT ctx = Context)
            {
                Period dataPeriod = (from p in ctx.Period
                                     where p.IdpEriod == id
                                     select p).FirstOrDefault();

                ctx.Period.DeleteOnSubmit(dataPeriod);
                ctx.SubmitChanges();
            }
        }
    }
}