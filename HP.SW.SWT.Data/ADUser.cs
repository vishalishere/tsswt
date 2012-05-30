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

        public static ENT.User Get(int id)
        {
            return (from u in Context.MyAspNetUsers
                    where u.ID == id
                    select new ENT.User
                    {
                        ID = u.ID,
                        Logon = u.Name,
                        Name = (from m in Context.MyAspNetMembership
                                where m.UserID == u.ID
                                select m.Comment).FirstOrDefault()
                    }).FirstOrDefault();
        }

        public static ENT.User GetByLogon(string logon)
        {
            return (from u in Context.MyAspNetUsers
                    where u.Name == logon
                    select new ENT.User
                    {
                        ID = u.ID,
                        Logon = u.Name,
                        Name = (from m in Context.MyAspNetMembership
                                where m.UserID == u.ID
                                select m.Comment).FirstOrDefault()
                    }).FirstOrDefault();
        }

        #endregion
    }
}
