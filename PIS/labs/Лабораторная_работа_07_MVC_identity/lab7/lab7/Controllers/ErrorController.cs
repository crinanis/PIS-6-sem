using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab7.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            // Обработка ошибки 404 - страница не найдена
            return View("Error");
        }

        // Другие методы обработки ошибок
    }

}