using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HP.SW.SWT.Entities;
using HP.SW.SWT.Extensions;

namespace HP.SW.SWT.MVC
{
    public static class DropDownListHelper
    {
        #region Entidades de la base de datos

        public static IEnumerable<SelectListItem> GetClusters()
        {
            return (from c in Data.ADCluster.GetAll()
                    orderby c.Description
                    select new SelectListItem { Value = c.ID.ToString(), Text = c.Description });
        }

        public static IEnumerable<SelectListItem> GetHolidays(int year)
        {
            return (from c in Data.ADHoliday.GetAll(year)
                    orderby c.Date
                    select new SelectListItem { Value = c.Date.ToString("yyyyMMdd"), Text = c.Description });
        }

        public static IEnumerable<SelectListItem> GetPeriods()
        {
            return (from p in Data.ADPeriod.GetAll()
                    orderby p.StartDate descending
                    select new SelectListItem { Value = p.ID.ToString(), Text = p.Description });
        }

        public static IEnumerable<SelectListItem> GetResources()
        {
            return (from r in Data.ADResource.GetAll()
                    orderby r.Name
                    select new SelectListItem { Value = r.T, Text = r.Name + " (" + r.T + ")" });
        }

        public static IEnumerable<SelectListItem> GetTickets()
        {
            return (from r in Data.ADTicket.GetAll(null, null)
                    orderby r.Number
                    select new SelectListItem { Value = r.Number, Text = r.Number });
        }

        public static IEnumerable<SelectListItem> GetUsers()
        {
            return (from r in Data.ADUser.GetAll()
                    orderby r.Name
                    select new SelectListItem { Value = r.Logon, Text = r.Name });
        } 

        #endregion

        #region Enumerados

        public static IEnumerable<SelectListItem> GetStatuses()
        {
            return Enums.Get<TicketStatus>().ConvertAll<SelectListItem>(e => new SelectListItem { Text = e.ToReadableString(), Value = e.ToString() });
        }

        public static IEnumerable<SelectListItem> GetPriorities()
        {
            return Enums.Get<TicketPriority>().ConvertAll<SelectListItem>(e => new SelectListItem { Text = e.ToReadableString(), Value = e.ToString() });
        }

        public static IEnumerable<SelectListItem> GetCategories()
        {
            return Enums.Get<TicketCategory>().ConvertAll<SelectListItem>(e => new SelectListItem { Text = e.ToReadableString(), Value = e.ToString() });
        } 

        #endregion
    }
}