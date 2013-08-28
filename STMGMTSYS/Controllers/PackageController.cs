using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTier.Package;
using STMGMTSYS.Models;
using DataTier;

namespace STMGMTSYS.Controllers
{
    public class PackageController : Controller
    {
        //
        // GET: /Package/

        public ActionResult Index()
        {

            Package sample = new Package() { PackageCode = "", PackageName = "" };
            List<PackageModel> packages = Utility.ConvetrToList<PackageModel, Package>(PackageManager.GetAllPackage(sample, "nirshan"));
            return View(packages);
        }

        //
        // GET: /Package/Details/5

        public ActionResult Details(int id)
        {
            PackageModel singlePackage = Utility.convertSrcToTarget<Package, PackageModel>(PackageManager.GetPackageByID(id, "nirshan"));
            return View(singlePackage);
        }

        //
        // GET: /Package/Create

        public ActionResult Create()
        {
            PackageModel newPackage = new PackageModel() { IsActive = true };
            return View(newPackage);
        }

        //
        // POST: /Package/Create

        [HttpPost]
        public ActionResult Create(PackageModel package)
        {
            try
            {
                PackageManager.AddPackage(Utility.convertSrcToTarget<PackageModel, Package>(package), "nirshan");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Package/Edit/5

        public ActionResult Edit(int id)
        {
            PackageModel singlePackage = Utility.convertSrcToTarget<Package, PackageModel>(PackageManager.GetPackageByID(id, "nirshan"));
            return View(singlePackage);
        }

        //
        // POST: /Package/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, PackageModel package)
        {
            try
            {
                PackageManager.UpdatePackage(Utility.convertSrcToTarget<PackageModel, Package>(package), "nirshan");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Package/Delete/5

        public ActionResult Delete(int id)
        {
            PackageManager.DeletePackage(id, "nirshan");
            return View();
        }

        //
        // POST: /Package/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
