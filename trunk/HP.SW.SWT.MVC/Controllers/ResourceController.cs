using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Data = HP.SW.SWT.Data;
using HP.SW.SWT.Entities;
using System.Web.Script.Services;
using System.Web.Security;

namespace HP.SW.SWT.MVC.Controllers
{
    [HandleError]
    public class ResourceController : BaseController
    {
        #region CRUD
        //
        // GET: /Resource/
        [Authorize(Roles = "Project Manager")]
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
        
        #endregion

        [HttpPost]
        [Authorize]
        public JsonResult GetCurrentAssignments()
        {
            return Json(from er in Data.ADExcelRow.GetCurrentAssignments()
                        select new 
                        { 
                            Resource = er.Resource.Name,
                            Ticket = er.Ticket
                        });
        }

        #region Excel

        [Authorize(Roles = "Project Manager, Referente, Desarrollador")]
        public ActionResult Excel()
        {
            return View(Data.ADExcelRow.Get(this.GetUser(), Data.ADPeriod.GetCurrentPeriod()));
        }

        [Authorize(Roles = "Project Manager")]
        public ActionResult ExcelView(string t, DateTime? date)
        {
            Resource resource = Data.ADResource.Get(t);
            ViewData["Resource"] = resource;
            IEnumerable<ExcelRow> excelRows;
            if (date.HasValue)
            {
                ViewData["Date"] = date;
                excelRows = Data.ADExcelRow.Get(Data.ADResource.Get(t), date.Value);
            }
            else
            {
                Period period = Data.ADPeriod.GetCurrentPeriod();
                ViewData["Period"] = period;
                excelRows = Data.ADExcelRow.Get(resource, period);
            }
            return View(excelRows);
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
                        Id = Data.ADExcelRow.Update(excelRow)
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
                        Id = Data.ADExcelRow.Insert(excelRow)
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
                        Id = Data.ADExcelRow.Delete(excelRow)
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        } 

        #endregion
    }
}
