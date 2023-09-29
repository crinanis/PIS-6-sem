using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab7.Controllers
{
    public class FltController : Controller
    {
        // GET: Flt
        [Authorize(Roles = "guest, employer")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Lv()
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Lu()
        {
            return View();
        }

        [Authorize(Roles = "employer")]
        public ActionResult Lz()
        {
            return View();
        }
    }
}