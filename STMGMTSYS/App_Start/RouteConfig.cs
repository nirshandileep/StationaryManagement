using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
 
namespace STMGMTSYS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "TwoParam",
                url: "{controller}/{action}/{modelParam}/{boolParam}",
                defaults: new { controller = "Customer", action = "CreateEdit", modelParam = UrlParameter.Optional, boolParam = UrlParameter.Optional }
            );

            //routes.MapRoute("Contact", "contact", new { controller = "Contact", action = "ContactForm" });

            //routes.MapRoute("Home", "{lang}", new { controller = "Home", action = "Index", lang = "english" });

           
            
        }
    }
}