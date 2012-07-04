using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HP.SW.SWT.Entities;
using HP.SW.SWT.Extensions;

namespace HP.SW.SWT.MVC.Controllers
{
    [HandleError]
    [Authorize]
    public class TicketController : BaseController
    {
        #region Ticket

        public ActionResult Index()
        {
            TicketFilterOptions ticketFilterOptions = new TicketFilterOptions();
            PagingOptions pagingOptions = new PagingOptions { Page = 1 };

            IEnumerable<Ticket> tickets = Data.ADTicket.GetAll(ticketFilterOptions, pagingOptions);

            ViewData["FirstPage"] = pagingOptions.FirstPage;
            ViewData["FirstRowNumber"] = pagingOptions.FirstRowNumber;
            ViewData["LastRowNumber"] = pagingOptions.LastRowNumber;
            ViewData["LastPage"] = pagingOptions.LastPage;
            return View(tickets);
        }

        [HttpPost]
        public JsonResult Index(FormCollection collection)
        {
            TicketFilterOptions ticketFilterOptions = new TicketFilterOptions();
            PagingOptions pagingOptions = new PagingOptions { Page = 1 };

            IEnumerable<Ticket> tickets = Data.ADTicket.GetAll(ticketFilterOptions, pagingOptions);

            ViewData["FirstPage"] = pagingOptions.FirstPage;
            ViewData["FirstRowNumber"] = pagingOptions.FirstRowNumber;
            ViewData["LastRowNumber"] = pagingOptions.LastRowNumber;
            ViewData["LastPage"] = pagingOptions.LastPage;
            return Json(tickets);
        }

        public ActionResult Details(string id)
        {
            return View(Data.ADTicket.Get(id));
        }

        private void LoadTicketCombos()
        {
            ViewData["Resources"] = DropDownListHelper.GetResources();
            ViewData["Statuses"] = DropDownListHelper.GetStatuses();
            ViewData["Priorities"] = DropDownListHelper.GetPriorities();
            ViewData["Categories"] = DropDownListHelper.GetCategories();
            ViewData["Clusters"] = DropDownListHelper.GetClusters();
        }

        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult Create()
        {
            LoadTicketCombos();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult Create(Ticket viewTicket)
        {
            Data.ADTicket.Insert(viewTicket, GetUser());

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult Edit(string id)
        {
            LoadTicketCombos();
            return View(Data.ADTicket.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult Edit(string id, Ticket viewTicket)
        {
            Ticket ticket = Data.ADTicket.Get(id);

            ticket.Title = viewTicket.Title;
            ticket.Resource = viewTicket.Resource;
            ticket.Status = viewTicket.Status;
            ticket.Priority = viewTicket.Priority;
            ticket.Description = viewTicket.Description;
            ticket.Category = viewTicket.Category;
            ticket.NewComment = viewTicket.NewComment;
            ticket.DeliveryDate = viewTicket.DeliveryDate;
            ticket.Cluster = viewTicket.Cluster;
            ticket.System = viewTicket.System;
            ticket.RealDeliveryDate = viewTicket.RealDeliveryDate;
            ticket.IsRework = viewTicket.IsRework;
            ticket.IsCertifiable = viewTicket.IsCertifiable;

            Data.ADTicket.Update(ticket, GetUser());

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult Delete(string id)
        {
            return View(Data.ADTicket.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult Delete(string id, Ticket viewTicket)
        {
            Data.ADTicket.Delete(id, GetUser());

            return RedirectToAction("Index");
        }

        #endregion

        #region Task

        public ActionResult Tasks(string id)
        {
            return View(Data.ADTicket.Get(id));
        }

        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult CreateTask(string id, TaskPhase phase, int number)
        {
            ViewData["Ticket"] = Data.ADTicket.Get(id);
            return View(new Task { TicketNumber = id, Phase = phase, Number = number });
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult CreateTask(string id, Task task)
        {
            Data.ADTask.Insert(id, task);

            return RedirectToAction("Tasks", new { id = id });
        }

        public ActionResult DetailsTask(int id)
        {
            Task task = Data.ADTask.Get(id);
            ViewData["Ticket"] = Data.ADTicket.Get(task.TicketNumber);
            return View(task);
        }

        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult EditTask(int id)
        {
            Task task = Data.ADTask.Get(id);
            ViewData["Ticket"] = Data.ADTicket.Get(task.TicketNumber);
            return View(task);
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult EditTask(int id, Task task)
        {
            Data.ADTask.Update(id, task);

            return RedirectToAction("Tasks", new { id = task.TicketNumber });
        }

        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult UpTask(string ticketNumber, int id)
        {
            Data.ADTask.Up(id);

            return RedirectToAction("Tasks", new { id = ticketNumber });
        }

        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult DownTask(string ticketNumber, int id)
        {
            Data.ADTask.Down(id);

            return RedirectToAction("Tasks", new { id = ticketNumber });
        }

        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult DeleteTask(int id)
        {
            Task task = Data.ADTask.Get(id);
            ViewData["Ticket"] = Data.ADTicket.Get(task.TicketNumber);
            return View(task);
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager, Referente")]
        public ActionResult DeleteTask(int id, Task task)
        {
            Data.ADTask.Delete(id);

            return RedirectToAction("Tasks", new { id = task.TicketNumber });
        }
        #endregion
    }
}