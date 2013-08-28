using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTier.Branch;
using STMGMTSYS.Models;
using DataTier;

namespace STMGMTSYS.Controllers
{
    public class BranchController : Controller
    {
        //
        // GET: /Branch/

        public ActionResult Index()
        {
            Branch srchBranch = new Branch() { BranchName = "", AddressLine1 = "", IsActive = true };
            List<Branch> branList = BranchManager.GetAllBranch(srchBranch, "nirshan");
            List<BranchModel> branchList = Utility.ConvetrToList<BranchModel, Branch>(branList);

            return View(branchList);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                string branchName = collection.GetValue("BranchName").AttemptedValue;
                string addressLine1 = collection.GetValue("AddressLine1").AttemptedValue;
                bool bIsActive = Request.Form.GetValues("active") != null && Request.Form.GetValues("active")[0] != null ? true : false;

                Branch srcBran = new Branch() { BranchName = branchName, AddressLine1 = addressLine1, IsActive = bIsActive };

                List<Branch> branch = new List<Branch>();
                List<BranchModel> branchModels = new List<BranchModel>();
                branch = BranchManager.GetAllBranch(srcBran, "nirshan");

                return View(Utility.ConvetrToList<BranchModel, Branch>(branch));
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Branch/Details/5

        public ActionResult Details(int id)
        {
            BranchModel branch = new BranchModel();
            branch = Utility.convertSrcToTarget<Branch, BranchModel>(BranchManager.GetBranchById(id, "nirshan"));
            return View(branch);
        }

        //
        // GET: /Branch/Create

        public ActionResult Create()
        {
            BranchModel branchModel = new BranchModel() { IsActive = true };
            return View(branchModel);
        }

        //
        // POST: /Branch/Create

        [HttpPost]
        public ActionResult Create(BranchModel branch)
        {
            try
            {
                BranchManager.AddBranch(Utility.convertSrcToTarget<BranchModel, Branch>(branch), "nirshan");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Branch/Edit/5

        public ActionResult Edit(int id)
        {
            BranchManager.GetBranchById(id, "nirshan");
            return View(Utility.convertSrcToTarget<Branch, BranchModel>(BranchManager.GetBranchById(id, "nirshan")));
        }

        //
        // POST: /Branch/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, BranchModel branch)
        {
            try
            {
                BranchManager.UpdateBranch(Utility.convertSrcToTarget<BranchModel, Branch>(branch), "nirshan");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Branch/Delete/5

        public ActionResult Delete(int id)
        {
            BranchManager.DeleteBranch(id, "nirshan");
            return RedirectToAction("Index");
        }

    }
}
