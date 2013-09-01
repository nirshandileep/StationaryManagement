using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTier.Transfer;
using System.Data.SqlTypes;
using STMGMTSYS.Models;
using DataTier;
using DataTier.Branch;

namespace STMGMTSYS.Controllers
{
    public class TransferController : Controller
    {
        //
        // GET: /Transfer/

        public ActionResult Index()
        {
            Transfer srchTransfer = new Transfer { TransferCode = "", TransferDate = (DateTime) SqlDateTime.MinValue, FromBranch = 0, ToBranch = 0 };
            List<Transfer> transferList = TransferManager.SearchTransfer(srchTransfer, "dini");
            List<TransferModel> transferModelList = Utility.ConvetrToList<TransferModel, Transfer>(transferList);
    
            return View();
        }


        public ActionResult Create()
        {
            TransferModel transfer = new TransferModel();

            List<Branch> fromBranchList = BranchManager.GetAllBranch(new Branch { BranchName = "", AddressLine1 = "", IsActive = true }, "dini");
            ViewBag.FromBranchList = fromBranchList;

            Branch[] tmpArray = new Branch[] { };
            fromBranchList.CopyTo(tmpArray);
            List<Branch> toBranchList = tmpArray.ToList();
            ViewBag.ToBranchList = toBranchList;



            return View(transfer);


        }

    }
}
