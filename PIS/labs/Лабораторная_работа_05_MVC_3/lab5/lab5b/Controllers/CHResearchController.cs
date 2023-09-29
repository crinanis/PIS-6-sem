using System;
using System.Web.Mvc;

namespace lab5b.Controllers
{
    public class CHResearchController : Controller
    {
        // GET: CHResearch
        [HttpGet]
        [Route("ad")]
        [OutputCache(Duration = 5)]
        public ActionResult AD()
        {
            var time = DateTime.Now.ToString();
            return Content(time + " Response result");
        }

        [HttpPost]
        [Route("ap")]
        [OutputCache(Duration = 7)]

        public ActionResult AP(string x, string y)
        {
            var time = DateTime.Now.ToString();
            return Content(time + $" X = {x}, Y = {y}");
        }
    }
}