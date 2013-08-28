using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTier.Supplier;
using STMGMTSYS.Models;
using DataTier;

namespace STMGMTSYS.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/

        public ActionResult Index()
        {
            Supplier srchSupplier               = new Supplier() { SupplierName = "", AddresssLine1 = "", IsActive = true };
            List<Supplier> supList              = SupplierManager.GetAllSupplier(srchSupplier, "nirshan");
            List<SupplierModel> supplierList    = Utility.ConvetrToList<SupplierModel, Supplier>(supList);
            
            return View(supplierList);
        }

        [HttpPost]
        public ActionResult Index(string SupplierName = "", string AddresssLine1 = "")
        {
            //get the non property checkbox value , find a more suitable way later
            bool bIsActive = Request.Form.GetValues("active") != null && Request.Form.GetValues("active")[0] != null ? true : false;

            Supplier srchSupplier = new Supplier() { SupplierName = SupplierName, AddresssLine1 = AddresssLine1, IsActive = bIsActive };
            List<Supplier> supList = SupplierManager.GetAllSupplier(srchSupplier, "nirshan");
            List<SupplierModel> supplierList = Utility.ConvetrToList<SupplierModel, Supplier>(supList);

            return View(supplierList);
        }

        public ActionResult Create()
        {
            TempData["tmpsupplierId"] = null;
            return RedirectToAction("ViewEdit");
        }

        public ActionResult Edit(int supplierId)
        {
            TempData["tmpsupplierId"] = supplierId;
            return RedirectToAction("ViewEdit");
        }

        public ActionResult Delete(int supplierId)
        {
            SupplierManager.DeleteSupplier(supplierId, "nirshan");
            return RedirectToAction("Index");
        }

        public ActionResult ViewEdit()
        {
            SupplierModel tmpSupplierModel = null;

            int? supplierId = (int?)TempData["tmpsupplierId"];
            if (supplierId.HasValue == false)
            {
                ViewBag.Title = "Create";
                ViewBag.Command = "Create";
                tmpSupplierModel = new SupplierModel() { IsActive = true };
            }
            else
            {
                ViewBag.Title = "Update";
                ViewBag.Command = "Update";

                Supplier editCustomer = SupplierManager.GetSupplierByID(supplierId.Value, "nirshan");
                tmpSupplierModel = Utility.convertSrcToTarget<Supplier, SupplierModel>(editCustomer);

            }

            return View(tmpSupplierModel);
        }

        [HttpPost]
        public ActionResult ViewEdit(SupplierModel supplier)
        {
            if (supplier.SupplierID <= 0)
            {
                SupplierManager.AddSupplier(Utility.convertSrcToTarget<SupplierModel, Supplier>(supplier), "nirshan");
            }
            else
            {
                SupplierManager.UpdateSupplier(Utility.convertSrcToTarget<SupplierModel, Supplier>(supplier), "nirshan");
            }

            return RedirectToAction("Index");
        }

    }
}
