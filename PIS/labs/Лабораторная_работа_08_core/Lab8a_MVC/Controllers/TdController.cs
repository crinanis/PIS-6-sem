using Lab8a_MVC.Interfaces;
using Lab8a_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8a_MVC.Controllers
{
    public class TdController : Controller
    {
        private ITD _tdService;

        public TdController(ITD tdService)
        {
            _tdService = tdService;
        }

        public ActionResult Index()
        {
            var model = _tdService.GetAll();
            return View(model);
        }

        public ActionResult Add(string phoneNumber, string ownerName)
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            var model = _tdService.Get(id);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = _tdService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSave(string phoneNumber, string ownerName)
        {
            _tdService.Add(phoneNumber, ownerName);
            return View("Index", _tdService.GetAll());
        }

        [HttpPost]
        public ActionResult DeleteSave(int id)
        {
            _tdService.Delete(id);
            return View("Index", _tdService.GetAll());
        }

        [HttpPost]
        public ActionResult UpdateSave(int id, string phoneNumber, string ownerName)
        {
            _tdService.Update(new Phone(id, phoneNumber, ownerName));
            return View("Index", _tdService.GetAll());
        }
    }
}
