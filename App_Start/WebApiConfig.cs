using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Refactored
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "ProductsAll",
                routeTemplate: "api/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
               name: "ProductsID",
               routeTemplate: "api/{controller}/{id}/",
               defaults: new { id = RouteParameter.Optional }
           );
            config.Routes.MapHttpRoute(
                 name: "Options",
                 routeTemplate: "api/{controller}/{id}/{action}/",
                 defaults: new { id = RouteParameter.Optional }
             );
            config.Routes.MapHttpRoute(
                name: "OptionsID",
                routeTemplate: "api/{controller}/{id}/{action}/{optionId}/",
                defaults: new { optionId = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DeleteOptionID",
                routeTemplate: "api/{controller}/{productid}/{action}/{optionId}/",
                defaults: new { productid = RouteParameter.Optional, optionId = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "ProductsName",
                routeTemplate: "api/{controller}/{name}",
                defaults: new { name = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
    }
}
