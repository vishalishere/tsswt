using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Data = HP.SW.SWT.Data;
using HP.SW.SWT.Entities;
using System.Web.Script.Services;

namespace HP.SW.SWT.MVC.Controllers
{
    [HandleError]
    public class ResourceController : Controller
    {
        //
        // GET: /Resource/
        [Authorize(Roles="Project Manager")]
        public ActionResult Index()
        {
            return View(Data.ADResource.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager")]
        public ActionResult Details(string id)
        {
            return View(Data.ADResource.Get(id.Replace("_", "\\")));
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager")]
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        [Authorize(Roles = "Project Manager")]
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
        [Authorize(Roles = "Project Manager")]
        public ActionResult Edit(string id)
        {
            return View(Data.ADResource.Get(id.Replace("_", "\\")));
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager")]
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
        [Authorize(Roles = "Project Manager")]
        public ActionResult Delete(string id)
        {
            return View(Data.ADResource.Get(id.Replace("_", "\\")));
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager")]
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
        [Authorize]
        public JsonResult GetCurrentAssignments()
        {
            return Json(from er in Data.ADResource.GetCurrentAssignments()
                        select new 
                        { 
                            Resource = er.Resource.Name,
                            Ticket = er.Ticket
                        });
        }

        [Authorize(Roles = "Referente, Desarrollador")]
        public ActionResult Excel()
        {
            ViewData["Resource"] = Data.ADResource.Get("T31210");
            Resource resource = (Resource)ViewData["Resource"];
            return View(Data.ADResource.GetExcel(resource, Data.ADPeriod.GetCurrentPeriod()));
        }

        [HttpPost]
        [Authorize(Roles = "Referente, Desarrollador")]
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
        [GenerateScriptType(typeof(Resource))]
        [Authorize(Roles = "Referente, Desarrollador")]
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
        [Authorize(Roles = "Referente, Desarrollador")]
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
