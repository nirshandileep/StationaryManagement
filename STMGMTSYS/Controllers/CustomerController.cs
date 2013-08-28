using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTier.Customer;
using STMGMTSYS.Models;
using DataTier;

namespace STMGMTSYS.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {

            Customer srchCustomer = new Customer() { CustomerCode = "", Name = "", IsActive = true };

            List<Customer> cusList = CustomerManager.GetAllCustomer(srchCustomer, "nirshan");

            List<CustomerModel> customerList = Utility.ConvetrToList<CustomerModel, Customer>(cusList);

            return View(customerList);
        }

        [HttpPost]
        public ActionResult Index(string name = "", string code = "")
        {
            //get the non property checkbox value , find a more suitable way later
            bool bIsActive = Request.Form.GetValues("active") != null && Request.Form.GetValues("active")[0] != null ? true : false;

            Customer srchCustomer = new Customer() { CustomerCode = code, Name = name, IsActive = bIsActive };

            List<Customer> cusList = CustomerManager.GetAllCustomer(srchCustomer, "dini");

            List<CustomerModel> customerList = Utility.ConvetrToList<CustomerModel, Customer>(cusList);

            return View(customerList);
        }


        public ActionResult Create()
        {
            //CustomerModel newCustomerModel = new CustomerModel();
            TempData["tmpCustomerCode"] = string.Empty;
            return RedirectToAction("CreateEdit");
        }

        public ActionResult Edit(string customerCode)
        {
            //Customer editCustomer = CustomerManager.GetCustomerByCode(customerCode, "dini");
            //CustomerModel editCustomerModel = Utility.convertSrcToTarget<Customer, CustomerModel>(editCustomer);
            TempData["tmpCustomerCode"] = customerCode;
            return RedirectToAction("CreateEdit");
        }

        public ActionResult CreateEdit()
        {
            CustomerModel tmpCusstomerModel = null;

            string customerCode = (string)TempData["tmpCustomerCode"];
            if (string.IsNullOrEmpty(customerCode))
            {
                ViewBag.Title = "Create";
                ViewBag.Command = "Create";
            }
            else
            {
                ViewBag.Title = "Update";
                ViewBag.Command = "Update";

                Customer editCustomer = CustomerManager.GetCustomerByCode(customerCode, "dini");
                tmpCusstomerModel = Utility.convertSrcToTarget<Customer, CustomerModel>(editCustomer);

            }

            return View(tmpCusstomerModel);
        }

        [HttpPost]
        public ActionResult CreateEdit(CustomerModel customer)
        {
            if (customer.CustomerID <= 0)
            {
                CustomerManager.AddCustomer(Utility.convertSrcToTarget<CustomerModel, Customer>(customer), "dini");
            }
            else
            {
                CustomerManager.UpdateCustomer(Utility.convertSrcToTarget<CustomerModel, Customer>(customer), "dini");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int customerID)
        {
            if (customerID > 0)
            {
                CustomerManager.DeleteCustomer(customerID, "dini");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(string customerCode)
        {
            Customer viewCustomer = CustomerManager.GetCustomerByCode(customerCode, "dini");
            CustomerModel viewCustomerModel = Utility.convertSrcToTarget<Customer, CustomerModel>(viewCustomer);
            return View(viewCustomerModel);
        }
    }
}
