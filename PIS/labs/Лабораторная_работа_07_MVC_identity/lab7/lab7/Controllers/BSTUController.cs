using lab7.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab7.Controllers
{
    public class BstuController : Controller
    {

        public BstuController()
        { 
        }

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.isAdmin = User.IsInRole("admin");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles="admin")]
        public ActionResult Config()
        {
            return View();
        }
    }
}