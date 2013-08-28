using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STMGMTSYS.Models;

namespace STMGMTSYS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string lang)
        {
            var model = new HomeModel();

            if (lang == "sinhala")
            {
                model.Message = "Ayubowan!!!";
            }
            else
            {
                model.Message = "Hello world!!!";
            }

            //ViewBag.Message = "Hello world!";

            //ViewData["message"] = "Hello world";


            return View(model);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}



    }
}
