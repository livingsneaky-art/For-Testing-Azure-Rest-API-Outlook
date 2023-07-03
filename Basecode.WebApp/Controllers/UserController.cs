using Basecode.Data.Models;
using Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data = _service.RetrieveAll();
            return View(data);
        }

        [HttpGet]
        public ActionResult AddView()
        {
            var userModel = new User();
            return PartialView("~/Views/User/_AddView.cshtml", userModel);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            _service.Add(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateView(int id)
        {
            var data = _service.GetById(id);
            return PartialView("~/Views/User/_UpdateView.cshtml", data);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            _service.Update(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteView(int id)
        {
            var data = _service.GetById(id);
            return PartialView("~/Views/User/_DeleteView.cshtml", data);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
