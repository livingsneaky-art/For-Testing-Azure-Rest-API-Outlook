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
    }
}
