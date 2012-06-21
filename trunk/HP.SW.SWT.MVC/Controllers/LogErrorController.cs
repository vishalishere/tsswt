using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HP.SW.SWT.MVC.Models;

namespace HP.SW.SWT.MVC.Controllers
{
    public class LogErrorController : Controller
    {
        [Authorize()]
        public ActionResult Index()
        {
            return View(new LogErrorIndexModel { Filter = new Entities.LogErrorFilterOptions(), Data = new List<Entities.LogError>() });
        }

        [HttpPost]
        [Authorize()]
        public ActionResult Index(Entities.LogErrorFilterOptions options)
        {
            return View(new LogErrorIndexModel { Filter = options, Data = Data.ADLogError.GetAll(options).OrderByDescending(l => l.Date) });
        }

        [Authorize()]
        public ActionResult Details(int id)
        {
            return View(Data.ADLogError.Get(id));
        }
    }
}
