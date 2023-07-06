using Basecode.Data.Models;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Text;

namespace Basecode.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="service">The User service.</param>
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
            try
            {
                var data = _service.RetrieveAll();
                _logger.Trace("Successfully retrieved all users");
                return View(data);
            }
            catch (Exception e)
            {
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return StatusCode(500, "Something went wrong.");
            }    
        }

        /// <summary>
        /// Displays the modal for adding a new user.
        /// </summary>
        /// <returns>A partial view with a User model.</returns>
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            // Check if model is invalid using its data annotations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var data = _service.Create(user);
                
                // If service layer validation is successful
                if (!data.Result)
                {
                    _logger.Trace("Create new user sucessful.");
                    // Tell AJAX to redirect to Index()
                    return Json(new { redirectToUrl = Url.Action("Index", "User") });
                }

                // If service layer validation failed
                _logger.Trace(ErrorHandling.SetLog(data));
                // The only service layer validation for now is checking whether the email has a domain
                // Since validation failed, add a new error to the model state
                ModelState.AddModelError("Email", "Email address must have a domain.");
                // Store the validation errors in a dictionary
                Dictionary<string,string> validationErrors = GetValidationErrors();
                // Return the validation errors as a JSON object
                return BadRequest(Json(validationErrors));
            }
            catch (Exception e)
            {
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return StatusCode(500, "Something went wrong.");
            }
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

            if (data == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/User/_UpdateView.cshtml", data);
        }

        /// <summary>
        /// Updates an existing user in the system.
        /// </summary>
        /// <param name="user">User object representing the user with updated information.</param>
        /// <returns>Redirect to the Index() action to display the list of users.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(User user)
        {
            // Check if model is invalid using its data annotations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var data = _service.Update(user);

                // If service layer validation is successful
                if (!data.Result)
                {
                    _logger.Trace("Update user sucessful.");
                    // Tell AJAX to redirect to Index()
                    return Json(new { redirectToUrl = Url.Action("Index", "User") });
                }

                // If service layer validation failed
                _logger.Trace(ErrorHandling.SetLog(data));
                // The only service layer validation for now is checking whether the email has a domain
                // Since validation failed, add a new error to the model state
                ModelState.AddModelError("Email", "Email address must have a domain.");
                // Store the validation errors in a dictionary;
                var validationErrors = GetValidationErrors();
                // Return the validation errors as a JSON object
                return BadRequest(Json(validationErrors));
            }
            catch (Exception e)
            {
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return StatusCode(500, "Something went wrong.");
            }
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

            if (data == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/User/_DeleteView.cshtml", data);
        }

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="id">Integer representing the ID of the user to be deleted.</param>
        /// <returns>Redirect to the Index() action to display the updated list of users.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets the validation errors of the model.
        /// </summary>
        /// <returns>A dictionary containing the validation errors.</returns>
        private Dictionary<string, string> GetValidationErrors()
        {
            var validationErrors = new Dictionary<string, string>();

            foreach (var key in ModelState.Keys)
            {
                var modelStateEntry = ModelState[key];

                foreach (var error in modelStateEntry.Errors)
                {
                    validationErrors.Add(key, error.ErrorMessage);
                }
            }

            return validationErrors;
        }

    }
}
