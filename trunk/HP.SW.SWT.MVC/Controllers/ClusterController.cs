using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HP.SW.SWT.Entities;

namespace HP.SW.SWT.MVC.Controllers
{
    public class ClusterController : Controller
    {
        //
        // GET: /Cluster/

        public ActionResult Index()
        {
            return View(Data.ADCluster.GetAll());
        }

        //
        // GET: /Cluster/Details/5

        public ActionResult Details(int id)
        {
            return View(Data.ADCluster.Get(id));
        }

        //
        // GET: /Cluster/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Cluster/Create

        [HttpPost]
        public ActionResult Create(Cluster cluster)
        {
            try
            {
                Data.ADCluster.Insert(cluster);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Cluster/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(Data.ADCluster.Get(id));
        }

        //
        // POST: /Cluster/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Cluster cluster)
        {
            try
            {
                Data.ADCluster.Update(id, cluster);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cluster/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(Data.ADCluster.Get(id));
        }

        //
        // POST: /Cluster/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Cluster cluster)
        {
            try
            {
                Data.ADCluster.Delete(id, cluster);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
