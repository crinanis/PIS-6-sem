using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab7.Controllers
{
    public class FitController : Controller
    {
        // GET: Fit
        [Authorize(Roles = "guest, employer")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Is() 
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Pi()
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Id()
        {
            return View();
        }
    }
}