using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;
using System;

namespace HP.SW.SWT.Data    
{
    public class ADHoliday : ADBase
    {
        #region Get's 
        public static IEnumerable<ENT.Holiday> GetAll(int year)
        {
            return from h in Context.Holiday
                   where h.Date.Year == year
                   select new ENT.Holiday
                   {
                       Date = h.Date,
                       Description = h.Description
                   };
                                                      
        }

        public static ENT.Holiday Get(DateTime date) //int id)
        {
            return (from h in Context.Holiday
                    where h.Date == date
                    select new ENT.Holiday
                    {
                        Date = h.Date,
                        Description = h.Description
                    }).FirstOrDefault();
        }
        #endregion 

        public static void Insert(ENT.Holiday holiday)
        {
            using (SwT ctx = Context)
            {
                Data.Holiday h = new Holiday
                {
                    Date = holiday.Date,
                    Description = holiday.Description
                };
                ctx.Holiday.InsertOnSubmit(h);
                ctx.SubmitChanges();
            }
        }

        public static void Update(DateTime date, ENT.Holiday holiday)//int id, ENT.Holiday holiday)
        {
            using (SwT ctx = Context)
            {
                Holiday dataHoliday = (from h in ctx.Holiday
                                       where h.Date == holiday.Date
                                       select h).FirstOrDefault();
                //dataHoliday.Date = holiday.Date;
                dataHoliday.Description = holiday.Description;
                ctx.SubmitChanges();
            }
        }

        public static void Delete(DateTime date, ENT.Holiday holiday)
        {
            using (SwT ctx = Context)
            {
                Holiday dataHoliday = (from h in ctx.Holiday
                                       where h.Date == holiday.Date
                                       select h).FirstOrDefault();
                ctx.Holiday.DeleteOnSubmit(dataHoliday);
                ctx.SubmitChanges();
            }
        }
    }
}
