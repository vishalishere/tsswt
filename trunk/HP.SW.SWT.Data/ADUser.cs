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
            //var myaspnetusers = (from u in Context.MyAspNetUsers
            //                        where u.Name == logon
            //                        select u.ID).FirstOrDefault();

            //var myaspnetmembership = (from m in Context.MyAspNetMembership
            //                    //where m.UserID == myaspnetusers
            //                    select m.Comment).FirstOrDefault();

            var userAux = (from u in Context.MyAspNetUsers
                        where u.Name == logon
                        select new ENT.User
                        {
                            ID = u.ID,
                            Logon = u.Name//,
                            //Name = membership
                        }).FirstOrDefault();

            var userName = (from m in Context.MyAspNetMembership
                              where m.UserID == userAux.ID
                              select m.Comment).FirstOrDefault();

            userAux.Name = userName;

            //return (from u in Context.MyAspNetUsers
            //        where u.Name == logon
            //        select new ENT.User
            //        {
            //            ID = u.ID,
            //            Logon = u.Name,
            //            Name = (from m in Context.MyAspNetMembership
            //                    where m.UserID == u.ID
            //                    select m.Comment).FirstOrDefault()
            //        }).FirstOrDefault();
            //Context.GetCommand(cons).CommandText
            return userAux;
        }

        #endregion
    }
}
