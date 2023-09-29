using System;
using System.Web;

namespace lab1
{
    public class Task5 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
            {
                var res = context.Response;
                res.WriteFile("d:\\1POIT\\3\\PIS\\labs\\1\\lab1\\lab1\\Task5.html");
            }
            else if (context.Request.HttpMethod == "POST")
            {
                int x = int.Parse(context.Request.Form["x"]);
                int y = int.Parse(context.Request.Form["y"]);
                context.Response.Write(x * y);
            }
        }

        #endregion
    }
}
