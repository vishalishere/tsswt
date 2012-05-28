using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HP.SW.SWT.Entities;

namespace HP.SW.SWT.MVC.Controllers
{
    public class HolidayController : Controller
    {
        //
        // GET: /Holiday/

        public ActionResult Index()
        {
            return View(Data.ADHoliday.GetAll(DateTime.Now.Year));
        }

        //
        // GET: /Holiday/Details/5

        public ActionResult Details(DateTime date) //int id)
        {
            return View(Data.ADHoliday.Get(date));
        }

        //
        // GET: /Holiday/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Holiday/Create

        [HttpPost]
        public ActionResult Create(Holiday holiday)
        {
            try
            {
                Data.ADHoliday.Insert(holiday);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Holiday/Edit/5
 
        public ActionResult Edit(DateTime date) //int id)
        {
            return View(Data.ADHoliday.Get(date));
        }

        //
        // POST: /Holiday/Edit/5

        [HttpPost]
        public ActionResult Edit(DateTime date, Holiday holiday) //int id, Holiday holiday)
        {
            try
            {
                Data.ADHoliday.Update(date, holiday);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Holiday/Delete/5
 
        public ActionResult Delete(DateTime date) //int id)
        {
            return View(Data.ADHoliday.Get(date));
        }

        //
        // POST: /Holiday/Delete/5

        [HttpPost]
        public ActionResult Delete(DateTime date, Holiday holiday) //int id, Holiday holiday)
        {
            try
            {
                Data.ADHoliday.Delete(date, holiday);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
