using System.Web.Mvc;
using System.Web.Routing;

namespace lab4
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
