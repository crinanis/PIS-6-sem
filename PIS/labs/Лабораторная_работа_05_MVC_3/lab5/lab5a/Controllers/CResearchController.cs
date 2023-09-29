using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace lab4a.Controllers
{
    public class CResearchController : Controller
    {
        // GET: CResearch

        [AcceptVerbs("get", "post")]
        public ActionResult C01()
        {
            StringBuilder template = new StringBuilder($"Method: {Request.HttpMethod}<br>")
                                               .Append($"Query params: {Request.QueryString}<br>")
                                               .Append($"Uri: {Request.Path}<br>");

            NameValueCollection headers = Request.Headers;

            template.Append("Headers:<br>");

            foreach (string key in headers.AllKeys)
            {
                foreach (string value in headers.GetValues(key))
                {
                    template.Append($"-- {key} : {value}<br>");
                }
            }

            var bodyStream = new StreamReader(Request.InputStream);
            bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
            template.Append($"Body: {bodyStream.ReadToEnd()}");


            return Content(template.ToString());
        }

        [AcceptVerbs("get", "post")]

        public ActionResult C02()
        {
            var template = new StringBuilder($"Status: {Response.Status}<br>");

            NameValueCollection headers = Response.Headers;

            template.Append("Headers:<br>");

            foreach (string key in headers.AllKeys)
            {
                foreach (string value in headers.GetValues(key))
                {
                    template.Append($"-- {key} : {value}<br>");
                }
            }

            var bodyStream = new StreamReader(Request.InputStream);
            bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
            template.Append($"Body: {bodyStream.ReadToEnd()}");

            return Content(template.ToString());
        }
    }
}