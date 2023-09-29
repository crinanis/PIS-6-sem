using IPhoneDictionary;
using Microsoft.Ajax.Utilities;
using System.Security.Policy;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class DictController : Controller
    {
        private IPhoneDictionary.IPhoneDictionary phones;

        public DictController(IPhoneDictionary.IPhoneDictionary phones)
        {
            this.phones = phones;
        }

        // GET: Dict
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.phones = phones.FindAll();
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
            try
            {
                PhoneBook phone = new PhoneBook();
                phone.surname = surname;
                phone.phoneNumber = phoneNumber;
                phones.Create(phone);
                return Redirect("~/Dict/Index");
            }
            catch
            {
                return Redirect("~/Dict/Error");
            }
        }

        [HttpGet]
        public ActionResult Update()
        {
            ViewBag.phones = phones.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(string surname, string phoneNumber)
        {
            try
            {
                phones.Update(surname, phoneNumber);
                return Redirect("~/Dict/Index");
            } catch
            {
                return Redirect("~/Dict/Error");
            }
        }

        [HttpGet]
        public ActionResult Delete()
        {
            ViewBag.phones = phones.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(string surname)
        {
            if (surname == null)
            {
                return Redirect("~/Dict/Error");
            }

            try
            {
                phones.Delete(surname);
                return Redirect("~/Dict/Index");
            }
            catch
            {
                return Redirect("~/Dict/Error");
            }
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }
    }
}