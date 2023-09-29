using System.Web.Mvc;

namespace lab5b.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        // GET: MResearch

        [HttpGet]
        [Route("{n:int}/{str}")]
        public ActionResult M01B(int n, string str)
        {
            string template = $"GET:M01: /{n}/{str}";
            return Content(template);
        }

        [AcceptVerbs("get", "post")]
        [Route("{b:bool}/{letters:length(3,4)}")]
        public ActionResult M02(bool b, string letters)
        {
            string template = $"{Request.HttpMethod}:M02: /{b}/{letters}";
            return Content(template);
        }

        [AcceptVerbs("get", "delete")]
        [Route("{f:float}/{str:length(2,5)}")]
        public ActionResult M03(float f, string str)
        {
            string template = $"{Request.HttpMethod}:M03: /{f}/{str}";
            return Content(template);
        }

        [HttpPut]
        [Route("{letters:length(3,4)}/{n:range(100,200)}")]
        public ActionResult M04(string letters, int n)
        {
            string template = $"PUT:M04: /{letters}/{n}";
            return Content(template); ;
        }

        [HttpPost]
        [Route(@"{mail:regex(\w{2,20}@mail.ru)}")]
        public ActionResult M05(string mail)
        {
            string template = $"POST:{mail}";
            return Content(template);
        }
    }
}