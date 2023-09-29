using System.Web.Mvc;

namespace lab4.Controllers
{
   public class ErrorController : Controller
   {
        // GET: Error
        public ActionResult NotFound(string catchall = null)
        {
            Response.Write($"{Request.HttpMethod}: {catchall} не поддерживается");
            return new HttpNotFoundResult();
        }
    }
}