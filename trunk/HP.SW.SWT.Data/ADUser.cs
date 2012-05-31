﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADUser : ADBase
    {
        #region Get

        private static string GetName(int id)
        {
            return (from m in Context.MyAspNetMembership
                    where m.UserID == id
                    select m.Comment).FirstOrDefault();
        }

        public static ENT.User Get(int id)
        {
            ENT.User user = (from u in Context.MyAspNetUsers
                             where u.ID == id
                             select new ENT.User
                             {
                                 ID = u.ID,
                                 Logon = u.Name
                             }).FirstOrDefault();

            user.Name = GetName(id);

            return user;
        }

        public static ENT.User GetByLogon(string logon)
        {
            ENT.User user = (from u in Context.MyAspNetUsers
                             where u.Name == logon
                             select new ENT.User
                             {
                                 ID = u.ID,
                                 Logon = u.Name//,
                                 //Name = membership
                             }).FirstOrDefault();

            if (user != null)
            {
                user.Name = GetName(user.ID);
            }

            return user;
        }

        #endregion
    }
}
