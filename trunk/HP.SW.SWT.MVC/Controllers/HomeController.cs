using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Data = HP.SW.SWT.Data;
using HP.SW.SWT.Entities;

namespace HP.SW.SWT.MVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        //[Authorize(Roles = "Project Manager")]
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Project Manager")]
        public JsonResult GetDashboardTickets(DashboardOrder order, string cluster)
        {
            IEnumerable<Ticket> tickets = Data.ADTicket.GetWorkingTickets(cluster);

            switch (order)
            {
                case DashboardOrder.ByCompletionPercentageAsc:
                    {
                        tickets = tickets.OrderBy(x => x.DonePercentage);
                        break;
                    }
                case DashboardOrder.ByCompletionPercentageDesc:
                    {
                        tickets = tickets.OrderByDescending(x => x.DonePercentage);
                        break;
                    }
                case DashboardOrder.ByDateDeviationAsc:
                    {
                        tickets = tickets.OrderBy(x => x.DeliveryDate == null ? 0 : (x.DeliveryDateForecast - x.DeliveryDate.Value).TotalMilliseconds);
                        break;
                    }
                case DashboardOrder.ByDateDeviationDesc:
                    {
                        tickets = tickets.OrderByDescending(x => x.DeliveryDate == null ? 0 : (x.DeliveryDateForecast - x.DeliveryDate.Value).TotalMilliseconds);
                        break;
                    }
                case DashboardOrder.ByHourDeviationAsc:
                    {
                        tickets = tickets.OrderBy(x => x.ConsumedHoursForecast / x.EstimatedHours);
                        break;
                    }
                case DashboardOrder.ByHourDeviationDesc:
                    {
                        tickets = tickets.OrderByDescending(x => x.ConsumedHoursForecast / x.EstimatedHours);
                        break;
                    }
            }

            // Solo se llevan al dashboard los tickets que se empezaron o los tickets que ya tienen comprometida fecha de entrega.
            return Json(from t in tickets
                        select new
                        {
                            Number = t.Number,
                            Cluster = t.Cluster,
                            Resource = t.Resource,
                            StartDate = t.StartDate ?? t.StartDateForecast,
                            DeliveryDate = t.DeliveryDate,
                            DeliveryDateForecast = t.DeliveryDateForecast,
                            ConsumedHoursForecast = t.ConsumedHoursForecast,
                            EstimatedHours = t.EstimatedHours,
                            DonePercentage = t.DonePercentage
                        });
        }

        public ActionResult About()
        {
            return View();
        }
    }
}