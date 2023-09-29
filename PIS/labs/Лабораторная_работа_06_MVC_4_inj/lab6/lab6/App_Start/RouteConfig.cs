using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lab6
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Dict",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Index" },
                constraints: new { controller = "Dict", action = "Index|Add|AddSave|Update|UpdateSave|Delete|DeleteSave|Error" }
            );

            routes.MapRoute(
                name: "Error404",
                url: "{*catchall}",
                defaults: new { controller = "Error", action = "NotFound" }
            );
        }
    }
}
