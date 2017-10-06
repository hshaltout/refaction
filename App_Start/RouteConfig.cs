using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Refactored
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
            // routes.MapRoute(
            //     name: "ProductsID",
            //     url: "{controller}/{id}/",
            //     defaults: new { controller = "Products", action = "ProductsID", id = UrlParameter.Optional }
            // );
            // routes.MapRoute(
            //     name: "Products",
            //     url: "{controller}/",
            //     defaults: new { controller = "Products", action = "Products", id = UrlParameter.Optional }
            // );
            // routes.MapRoute(
            //     name: "Options",
            //     url: "{controller}/{id}/{action}/",
            //     defaults: new { controller = "Products", action = "Options", id = UrlParameter.Optional }
            // );
            // routes.MapRoute(
            //    name: "OptionsID",
            //    url: "{controller}/{id}/{action}/{optionId}/",
            //    defaults: new { controller = "Products", action = "OptionsID", id = UrlParameter.Optional }
            //);
        }
    }
}
