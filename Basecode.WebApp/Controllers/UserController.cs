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

        /// <summary>
        /// Displays the list of all users.
        /// </summary>
        /// <returns>A view containing all users as a list of UserViewModel objects.</returns>
        public IActionResult Index()
        {
            var data = _service.RetrieveAll();
            return View(data);
        }

        /// <summary>
        /// Displays the modal for adding a new user.
        /// </summary>
        /// <returns>A partial view and a User model.</returns>
        [HttpGet]
        public ActionResult AddView()
        {
            var userModel = new User();
            return PartialView("~/Views/User/_AddView.cshtml", userModel);
        }

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="user">User object representing the user to be added.</param>
        /// <returns>Redirect to the Index() action to display the list of users.</returns>
        [HttpPost]
        public IActionResult Add(User user)
        {
            _service.Add(user);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the modal for updating an existing user.
        /// </summary>
        /// <param name="id">Integer representing the ID of the user to be updated.</param>
        /// <returns>A partial view and User object.</returns>
        [HttpGet]
        public ActionResult UpdateView(int id)
        {
            var data = _service.GetById(id);
            return PartialView("~/Views/User/_UpdateView.cshtml", data);
        }

        /// <summary>
        /// Updates an existing user in the system.
        /// </summary>
        /// <param name="user">User object representing the user with updated information.</param>
        /// <returns>Redirect to the Index() action to display the list of users.</returns>
        [HttpPost]
        public IActionResult Update(User user)
        {
            _service.Update(user);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the modal for deleting an existing user.
        /// </summary>
        /// <param name="id">Integer representing the ID of the user to be deleted.</param>
        /// <returns>A partial view and User object.</returns>
        [HttpGet]
        public ActionResult DeleteView(int id)
        {
            var data = _service.GetById(id);
            return PartialView("~/Views/User/_DeleteView.cshtml", data);
        }

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="id">Integer representing the ID of the user to be deleted.</param>
        /// <returns>Redirect to the Index() action to display the updated list of users.</returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
