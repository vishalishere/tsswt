﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HP.SW.SWT.Entities;
using HP.SW.SWT.MVC.Models;

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
        [Authorize(Roles = "Project Manager, Referente, Desarrollador")]
        public JsonResult AddExcelRow(ExcelRowModel excelRow)
        {
            try
            {
                excelRow.Resource = GetUserAsResource();
                Data.ADLogError.LogInfo("AddExcelRow --> Fecha: " + excelRow.Date.ToString("g"), GetUser());
                return Json(new
                {
                    result = "Ok",
                    data = new
                    {
                        rowIndex = excelRow.RowIndex,
                        id = Data.ADExcelRow.Insert(excelRow)
                    }
                });
            }
            catch (Exception ex)
            {
                return HandlePOSTError(ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager, Referente, Desarrollador")]
        public JsonResult UpdateExcelRows(List<ExcelRowModel> excelRows)
        {
            try
            {
                Resource res = GetUserAsResource();

                excelRows.ForEach(x =>
                {
                    x.Resource = new Resource();
                    x.Resource.Cluster = res.Cluster;
                    x.Resource.Name = res.Name;
                    x.Resource.T = res.T;

                    x.Id = Data.ADExcelRow.Update(x);
                });

                return Json(new
                {
                    result = "Ok",
                    data = new
                    {
                        ids = (from e in excelRows
                               select new { rowIndex = e.RowIndex, id = e.Id })
                    }
                });
            }
            catch (Exception ex)
            {
                return HandlePOSTError(ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager, Referente, Desarrollador")]
        public JsonResult DeleteExcelRow(ExcelRow excelRow, int rowIndex)
        {
            try
            {
                Data.ADExcelRow.Delete(excelRow);
                return Json(new
                {
                    result = "Ok",
                    data = new
                    {
                        rowIndex = rowIndex
                    }
                });
            }
            catch (Exception ex)
            {
                //return Json(new { Result = "Error", Message = ex.Message });
                return HandlePOSTError(ex);
            }
        }

        [Authorize(Roles = "Project Manager")]
        public ActionResult Import()
        {
            ViewData["Periods"] = DropDownListHelper.GetPeriods();
            ViewData["Resources"] = DropDownListHelper.GetResources();
            return View();
        }

        [Authorize(Roles = "Project Manager")]
        [HttpPost]
        public ActionResult Import(int? periodId, string T, HttpPostedFileBase file)
        {
            try
            {
                if (!periodId.HasValue)
                {
                    throw new Exception("Seleccione un período.");
                }

                if (string.IsNullOrEmpty(T))
                {
                    throw new Exception("Seleccione un recurso.");
                }

                if (file == null)
                {
                    throw new Exception("Seleccione un archivo.");
                }

                if (file.ContentLength == 0)
                {
                    throw new Exception("Seleccione un archivo no vacío.");
                }

                Data.ADExcelRow.Import(Data.ADPeriod.Get(periodId.Value), Data.ADResource.Get(T), file.InputStream);

                ViewData["resultColor"] = "Blue";
                ViewData["result"] = "Los datos se incorporaron correctamente.";
            }
            catch (Exception ex)
            {
                ViewData["resultColor"] = "Red";
                ViewData["result"] = string.Format("Hubo un error al incorporar los datos ({0}).", ex.Message);
            }

            return Import();
        }

        #endregion
    }
}
