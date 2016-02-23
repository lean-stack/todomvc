using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TodoMVC.Backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "TodoApi",
                routeTemplate: "api/todos/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "WebAPITodos" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
