﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HP.SW.SWT.Entities;

namespace HP.SW.SWT.MVC.Controllers
{
    public class TicketController : Controller
    {
        //
        // GET: /Ticket/

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

        //
        // GET: /Ticket/Details/5

        public ActionResult Details(string id)
        {
            return View(Data.ADTicket.Get(id));
        }

        //
        // GET: /Ticket/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Ticket/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Ticket/Edit/5

        public ActionResult Edit(string id)
        {
            return View(Data.ADTicket.Get(id));
        }

        //
        // POST: /Ticket/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                Ticket ticket = Data.ADTicket.Get(id);

                Data.ADTicket.Update(ticket);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ticket/Delete/5

        public ActionResult Delete(string id)
        {
            return View(id);
        }

        //
        // POST: /Ticket/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                Data.ADTicket.Delete(id, null);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}