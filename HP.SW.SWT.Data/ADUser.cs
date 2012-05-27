using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADUser : ADBase
    {
        #region Get

        public static ENT.User GetByLogon(string logon)
        {
            return (from u in Context.Users
                    where u.Username == logon
                    select new ENT.User
                    {
                        ID = u.PKid,
                        Logon = u.Username,
                        Name = u.Comment
                    }).FirstOrDefault();
        }

        #endregion
    }
}
