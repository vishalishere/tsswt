using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Data = HP.SW.SWT.Data;
using HP.SW.SWT.Entities;

namespace HP.SW.SWT.MVC.Controllers
{
    public class ResourceController : Controller
    {
        //
        // GET: /Resource/
        public ActionResult Index()
        {
            return View(Data.ADResource.GetAll());
        }

        [HttpPost]
        public ActionResult Details(string id)
        {
            return View(Data.ADResource.Get(id.Replace("_", "\\")));
        }

        [HttpPost]
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult CreateOk(FormCollection collection)
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

        [HttpPost]
        public ActionResult Edit(string id)
        {
            return View(Data.ADResource.Get(id.Replace("_", "\\")));
        }

        [HttpPost]
        public ActionResult EditOk(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            return View(Data.ADResource.Get(id.Replace("_", "\\")));
        }

        [HttpPost]
        public ActionResult DeleteOk(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GetCurrentAssignments()
        {
            return Json(from er in Data.ADResource.GetCurrentAssignments()
                        select new 
                        { 
                            Resource = er.Resource.Name,
                            Ticket = er.Ticket
                        });
        }

        public ActionResult Excel()
        {
            return View(Data.ADResource.GetExcel("T31210", Data.ADPeriod.GetCurrentPeriod()));
        }

        [HttpPost]
        public JsonResult UpdateExcelRow(ExcelRow excelRow, int rowIndex)
        {            
            try
            {
                return Json(new
                {
                    Result = "Ok",
                    Data = new
                    {
                        RowIndex = rowIndex,
                        Id = Data.ADResource.UpdateExcelRow(excelRow)
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult AddExcelRow(ExcelRow excelRow, int rowIndex)
        {
            try
            {
                return Json(new
                {
                    Result = "Ok",
                    Data = new
                    {
                        RowIndex = rowIndex,
                        Id = Data.ADResource.AddExcelRow(excelRow)
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteExcelRow(ExcelRow excelRow, int rowIndex)
        {
            try
            {
                return Json(new
                {
                    Result = "Ok",
                    Data = new
                    {
                        RowIndex = rowIndex,
                        Id = Data.ADResource.DeleteExcelRow(excelRow)
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }
    }
}
