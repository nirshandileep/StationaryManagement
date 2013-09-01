using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTier.Package;
using STMGMTSYS.Models;
using DataTier;
using DataTier.Item;

namespace STMGMTSYS.Controllers
{
    public class PackageController : Controller
    {
        //
        // GET: /Package/

        public ActionResult Index()
        {

            Package sample = new Package() { PackageCode = "", PackageName = "", IsActive = true };
            List<PackageModel> packages = Utility.ConvetrToList<PackageModel, Package>(PackageManager.GetAllPackage(sample, "nirshan"));

            List<SelectListItem> Items;
            Items = GetItemsSelectList();
            ViewBag.Items = Items;

            return View(packages);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //get the non property checkbox value , find a more suitable way later
            bool bIsActive = Request.Form.GetValues("active") != null && Request.Form.GetValues("active")[0] != null ? true : false;
            string item = Request.Form.GetValues("Items") != null ? Request.Form.GetValues("Items")[0] : "";
            
            Package srchPackage = new Package();
            srchPackage.ItemID = int.Parse(item.ToString());
            srchPackage.PackageName = collection["name"].Trim();
            srchPackage.IsActive = bIsActive;
            srchPackage.PackageCode = "";

            List<Package> packList = PackageManager.GetAllPackage(srchPackage, "nirshan");
            List<PackageModel> customerList = Utility.ConvetrToList<PackageModel, Package>(packList);

            List<SelectListItem> Items;
            Items = GetItemsSelectList();
            ViewBag.Items = Items;

            return View(customerList);
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

            List<SelectListItem> Items;
            Items = GetItemsSelectList();
            ViewBag.Items = Items;
            return View(newPackage);
        }

        private static List<SelectListItem> GetItemsSelectList()
        {
            List<SelectListItem> Items;
            List<Item> allItems = ItemManager.GetAllItem(new Item() { ItemCode = "", IsActive = true, Name = "" }, "nirshan");
            Items = allItems.Select(map =>
                    new SelectListItem
                    {
                        Text = map.ItemCode,
                        Value = map.ItemID.ToString()
                    }).ToList();
            return Items;
        }

        //
        // POST: /Package/Create

        [HttpPost]
        public ActionResult Create(PackageModel package)
        {
            try
            {

                string item = Request.Form.GetValues("Items") != null ? Request.Form.GetValues("Items")[0] : "";
                package.Item = ItemManager.GetItemByID(int.Parse(item.ToString()), "nirshan");
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
                PackageManager.DeletePackage(id, "nirshan");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
