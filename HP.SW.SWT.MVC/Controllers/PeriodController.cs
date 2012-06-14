using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HP.SW.SWT.Entities;
using HP.SW.SWT.MVC.Models;


namespace HP.SW.SWT.MVC.Controllers
{
    public class PeriodController : Controller
    {
        #region CRUD
        //
        // GET: /Period/
        [Authorize(Roles = "Project Manager, Administrador")]
        public ActionResult Index()
        {
            return View(Data.ADPeriod.GetAll());
        }

        //
        // GET: /Period/Details/5
        [Authorize(Roles = "Project Manager, Administrador")]
        public ActionResult Details(int id)
        {
            return View(Data.ADPeriod.Get(id));
        }

        //
        // GET: /Period/Create
        [Authorize(Roles = "Project Manager, Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Period/Create
        [HttpPost]
        [Authorize(Roles = "Project Manager, Administrador")]
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
        [Authorize(Roles = "Project Manager, Administrador")]
        public ActionResult Edit(int id)
        {
            return View(Data.ADPeriod.Get(id));
        }

        //
        // POST: /Period/Edit/5
        [HttpPost]
        [Authorize(Roles = "Project Manager, Administrador")]
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
        [Authorize(Roles = "Project Manager, Administrador")]
        public ActionResult Delete(int id)
        {
            return View(Data.ADPeriod.Get(id));
        }

        //
        // POST: /Period/Delete/5
        [HttpPost]
        [Authorize(Roles = "Project Manager, Administrador")]
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

        #endregion

        #region MonthlyHours

        [Authorize(Roles = "Project Manager")]
        public ActionResult MonthlyHours(MonthlyHoursModel model)
        {
            ViewData["Periods"] = DropDownListHelper.GetPeriods();

            if (model == null)
            {
                model = new MonthlyHoursModel();
            }

            if (model.Period != null)
            {
                model.Period = Data.ADPeriod.Get(model.Period.ID);
            }
            else
            {
                model.Period = Data.ADPeriod.GetCurrentPeriod();
            }
            List<MonthlyHoursModelEstimated> monthlyHoursEstimated = new List<MonthlyHoursModelEstimated>();
            List<MonthlyHoursModelReal> monthlyHoursReal = new List<MonthlyHoursModelReal>();

            ResourceAssignment radEstimated;
            IEnumerable<ResourceRealDay> radReal;
            foreach (Resource resource in Data.ADResource.GetAll())
            {
                radEstimated = Data.ADResourceAssignment.Get(resource, model.Period);
                if (radEstimated != null)
                {
                    monthlyHoursEstimated.Add(new MonthlyHoursModelEstimated { Resource = resource, HoursByDay = radEstimated.Days });
                }

                radReal = Data.ADExcelRow.GetMonthlyHoursReal(resource, model.Period);
                if (radReal != null)
                {
                    monthlyHoursReal.Add(new MonthlyHoursModelReal { Resource = resource, HoursByDay = radReal });
                }
            }

            model.MonthlyHoursEstimated = monthlyHoursEstimated;
            model.MonthlyHoursReal = monthlyHoursReal;

            return View(model);
        }

        [Authorize(Roles = "Project Manager")]
        public ActionResult DashboardReport(int id)
        {
            try
            {
                Period period = Data.ADPeriod.Get(id);

                decimal nonScheduledAbsences = 0;
                decimal leverage = 0;
                Data.ADExcelRow.GetNonScheduledAbsencesAndLeverage(period, out nonScheduledAbsences, out leverage);
                return View(new DashboardReportModel
                {
                    Initial = Data.ADResourceAssignment.GetMonthlyHoursInitial(period),
                    ScheduledAbsences = Data.ADResourceAssignment.GetScheduledAbsences(period),
                    NonScheduledAbsences = nonScheduledAbsences,
                    Rework = Data.ADExcelRow.GetRework(period),
                    NonCertifiable = Data.ADExcelRow.GetNonCertifiable(period),
                    Leverage = leverage
                });

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}