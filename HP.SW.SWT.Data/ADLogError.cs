using System;
using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADLogError : ADBase
    {
        #region Gets
        public static IEnumerable<ENT.LogError> GetAll(ENT.LogErrorFilterOptions lEFOptions)
        {
            var res = (from r in Context.LogError
                    select new ENT.LogError
                    {
                        ID = r.IdlOgError,
                        Date = r.Date,
                        Message = r.Message,
                        StackTrace = r.StackTrace,  
                        User = new Entities.User { ID = r.IduSer }
                    });

            if (lEFOptions.Id.HasValue)
            {
                res = res.Where(x => x.ID == lEFOptions.Id.Value);
            }
            if (lEFOptions.DateFrom.HasValue)
            {
                res = res.Where(x => x.Date >= lEFOptions.DateFrom.Value);
            }
            if (lEFOptions.DateTo.HasValue)
            {
                res = res.Where(x => x.Date <= lEFOptions.DateTo.Value);
            }

            res.ToList().ForEach(x => x.User = ADUser.Get(x.User.ID));

            return res;
        }

        public static ENT.LogError Get(int id)
        {
            var res =  (from r in Context.LogError
                    where r.IdlOgError == id
                    select new ENT.LogError
                    {
                         ID = r.IdlOgError,
                         Date = r.Date,
                         Message = r.Message,  
                         StackTrace = r.StackTrace,
                         User = new Entities.User { ID = r.IduSer }
                    }).FirstOrDefault();

            if (res != null)
                res.User = ADUser.Get(res.User.ID);

            return res;                
        }
        #endregion

        public static int Insert(ENT.LogError logError)
        {
            using (SwT ctx = Context)
            {
                Data.LogError p = new LogError
                {
                    IdlOgError = logError.ID,
                    Date = logError.Date,
                    IduSer = logError.User.ID,
                    Message = logError.Message,
                    StackTrace = logError.StackTrace
                };

                ctx.LogError.InsertOnSubmit(p);
                ctx.SubmitChanges();

                return p.IdlOgError;
            }
        }

    }
}