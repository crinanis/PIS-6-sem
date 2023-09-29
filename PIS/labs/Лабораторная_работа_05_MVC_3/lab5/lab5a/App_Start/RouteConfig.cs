using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace lab5a
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "V3/Controller/X/Action",
                url: "V3/{controller}/{x}/{action}",
                defaults: new { controller = "MResearch", action = "M03", x = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "V2/Controller/Action",
                url: "V2/{controller}/{action}",
                defaults: new { controller = "MResearch", action = "M02" },
                constraints: new { action = "(?!M03).*" }
            );

            routes.MapRoute(
                name: "Controller/Action/Id",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional },
                constraints: new { action = "(?!M03).*" }
            );


            //C01 C02
            routes.MapRoute(
                name: "CResearch",
                url: "{controller}/{action}",
                defaults: new { controller = "CResearch", action = "C01" },
                constraints: new { controller = "CResearch", action = "C01" }
            );

            routes.MapRoute(
                name: "CResearch2",
                url: "{controller}/{action}",
                defaults: new {  },
                constraints: new { controller = "CResearch", action = "C02" }
            );

            routes.MapRoute(
                name: "404",
                url: "{controller}/{action}/{*catchall}",
                defaults: new { controller = "MResearch", action = "MXX" }
            );
        }
    }
}

//routes.MapRoute(
//    name: "V/contr/action2", 
//    url: "V3/{controller}/X/{action}", 
//    defaults: new { controller = "MResearch", action = "M03" }, 
//    constraints: new { action = "M03|M01" });

//routes.MapRoute(
//    name: "V/contr/action", 
//    url: "V2/{controller}/{action}", 
//    defaults: new { controller = "MResearch", action = "M02" }, 
//    constraints: new { action = "M02|M01" });
//routes.MapRoute(
//    name: "contr/action/id", 
//    url: "{controller}/{action}/{id}", 
//    defaults: new { controller = "MResearch", 
//        action = "M01", id = UrlParameter.Optional }, 
//    constraints: new { action = "M02|M01", id = "1|", });