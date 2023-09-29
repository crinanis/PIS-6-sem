using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab7.Controllers
{
    public class FieController : Controller
    {
        // GET: Fie
        [Authorize(Roles = "guest, employer")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Tm()
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Ur()
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Up()
        {
            return View();
        }
    }
}