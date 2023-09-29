using System.Web.Mvc;

namespace lab3.Controllers
{
    public class DictController : Controller
    {
        private TelephoneBook Book { get; set; } = new TelephoneBook();

        // GET: Dict

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.TelephoneBook = Book.GetAll();
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
            if (!Book.AddBook(surname, phoneNumber))
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