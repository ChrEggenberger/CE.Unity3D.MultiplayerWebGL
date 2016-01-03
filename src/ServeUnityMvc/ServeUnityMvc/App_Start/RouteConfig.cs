using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ServeUnityMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // unity static file route handler. routes requests to /data/ js mem data files to UnityStaticFile controller's Index action
            routes.RouteExistingFiles = true;
            routes.MapRoute("UnityStaticFiles", "Release/{*file}", new { Controller = "UnityStaticFile", action = "Index", path="Release" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}