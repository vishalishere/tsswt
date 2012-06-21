using System;
using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;
using System.Configuration;

namespace HP.SW.SWT.Data
{
    public class ADLogError : ADBase
    {
        #region Gets
        public static IEnumerable<ENT.LogError> GetAll(ENT.LogErrorFilterOptions lEFOptions)
        {
            var logError = (from r in Context.LogError
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
                logError= logError.Where(x => x.ID == lEFOptions.Id.Value);
            }
            if (lEFOptions.DateFrom.HasValue)
            {
                logError= logError.Where(x => x.Date >= lEFOptions.DateFrom.Value);
            }
            if (lEFOptions.DateTo.HasValue)
            {
                logError= logError.Where(x => x.Date <= lEFOptions.DateTo.Value);
            }

            List<ENT.LogError> res = logError.ToList();
            res.ForEach(x => x.User = Data.ADUser.Get(x.User.ID));

            return res;
        }

        public static ENT.LogError Get(int id)
        {
            ENT.LogError res = (from r in Context.LogError
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
            {
                res.User = Data.ADUser.Get(res.User.ID);
            }

            return res;
        }
        #endregion

        private static int Insert(ENT.LogError logError)
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

        public static int Log(Exception ex, ENT.User user)
        {
            bool logError = string.IsNullOrEmpty(ConfigurationManager.AppSettings["LogError"]) ? true :
                Boolean.Parse(ConfigurationManager.AppSettings["LogError"]);

            if (logError)
            {
                return ADLogError.Insert(new ENT.LogError
                {
                    Date = DateTime.Now,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    User = user
                });
            }
            else
            {
                return -1;
            }
        }

        public static int LogInfo(string message, ENT.User user)
        {
            bool logInfo = string.IsNullOrEmpty(ConfigurationManager.AppSettings["LogInfo"]) ? true :
                Boolean.Parse(ConfigurationManager.AppSettings["LogInfo"]);

            if (logInfo)
            {
                return ADLogError.Insert(new ENT.LogError
                {
                    Date = DateTime.Now,
                    Message = message,
                    StackTrace = string.Empty,
                    User = user
                });
            }
            else
            {
                return -1;
            }
        }
    }
}