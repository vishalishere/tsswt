using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data    
{
    public class ADHoliday : ADBase
    {
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
    }
}
