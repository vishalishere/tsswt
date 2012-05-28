using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HP.SW.SWT.Entities;


namespace HP.SW.SWT.MVC.Controllers
{
    public class PeriodController : Controller
    {
        //
        // GET: /Period/

        public ActionResult Index()
        {
            return View(Data.ADPeriod.GetAll());
        }

        //
        // GET: /Period/Details/5

        public ActionResult Details(int id)
        {
            return View(Data.ADPeriod.Get(id));
        }

        //
        // GET: /Period/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Period/Create

        [HttpPost]
        public ActionResult Create(Period period) //FormCollection collection)
        {
            try
            {
                Data.ADPeriod.Insert(period);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Period/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(Data.ADPeriod.Get(id));
        }

        //
        // POST: /Period/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Period period)
        {
            try
            {
                Data.ADPeriod.Update(id, period);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Period/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(Data.ADPeriod.Get(id));
        }

        //
        // POST: /Period/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Period period)
        {
            try
            {
                Data.ADPeriod.Delete(id);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
