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
            ViewData["Resources"] = Data.ADResource.GetAll().OrderBy(r => r.Name).ToList().
                ConvertAll<SelectListItem>(r => new SelectListItem { Value = r.T, Text = r.Name + " (" + r.T + ")" });
            ViewData["Statuses"] = new List<SelectListItem>
                { 
                    new SelectListItem
                    { 
                        Text = "Recibido", 
                        Value = ((int)TicketStatus.Recibido).ToString() 
                    },
                    new SelectListItem
                    { 
                        Text = "En Analisis", 
                        Value = ((int)TicketStatus.EnAnalisis).ToString() 
                    },
                    new SelectListItem
                    { 
                        Text = "Estimado", 
                        Value = ((int)TicketStatus.Estimado).ToString() 
                    },
                    new SelectListItem
                    { 
                        Text = "En Desarrollo", 
                        Value = ((int)TicketStatus.EnDesarrollo).ToString() 
                    },
                    new SelectListItem
                    { 
                        Text = "Entregado", 
                        Value = ((int)TicketStatus.Entregado).ToString() 
                    },
                };
            ViewData["Priorities"] = new List<SelectListItem>
                { 
                    new SelectListItem
                    { 
                        Text = "Alta", 
                        Value = ((int)TicketPriority.High).ToString() 
                    },
                    new SelectListItem
                    { 
                        Text = "Normal", 
                        Value = ((int)TicketPriority.Normal).ToString() 
                    },
                    new SelectListItem
                    { 
                        Text = "Baja", 
                        Value = ((int)TicketPriority.Low).ToString() 
                    }
                };
            ViewData["Categories"] = new List<SelectListItem>
                { 
                    new SelectListItem
                    { 
                        Text = "Incidencia", 
                        Value = ((int)TicketCategory.Incident).ToString() 
                    },
                    new SelectListItem
                    { 
                        Text = "Cambio Menor", 
                        Value = ((int)TicketCategory.MinorChange).ToString() 
                    },
                    new SelectListItem
                    { 
                        Text = "Evolutivo", 
                        Value = ((int)TicketCategory.Evolutive).ToString() 
                    }
                };

            ViewData["Clusters"] = Data.ADCluster.GetAll().OrderBy(r => r.Description).ToList().
                ConvertAll<SelectListItem>(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Description });

            return View(Data.ADTicket.Get(id));
        }

        //
        // POST: /Ticket/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, Ticket viewTicket)
        {
            try
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

                Data.ADTicket.Update(ticket, new User { ID = 1 });
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(Data.ADTicket.Get(id));
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
