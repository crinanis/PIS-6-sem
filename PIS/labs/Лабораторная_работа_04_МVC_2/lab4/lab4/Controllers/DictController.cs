using lab4.Context;
using System.Web.Mvc;

namespace lab4.Controllers
{
    public class DictController : Controller
    {
        private PhoneBookContext Book { get; set; } = new PhoneBookContext();

        // GET: Dict

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.PhoneBook = Book.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(string surname, string phoneNumber)
        {
            if (!Book.AddRow(surname, phoneNumber))
            {
                return Redirect("/Dict/Error");
            }
            return Redirect("/Dict/Index");
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(int? id, string surname, string phoneNumber)
        {
            if (!id.HasValue)
            {
                return Redirect("/Dict/Error");
            }

            if (!Book.Update(id.Value, surname, phoneNumber))
            {
                return Redirect("/Dict/Error");
            }
            return Redirect("/Dict/Index");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(int? id)
        {
            if (!id.HasValue)
            {
                return Redirect("/Dict/Error");
            }

            if (!Book.Delete(id.Value))
            {
                return Redirect("/Dict/Error");
            }

            return Redirect("/Dict/Index");
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }
    }
}