using Basecode.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Displays the login view
        /// </summary>
        /// <returns>The login view</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Redirect to dashboard when sign-up successfully
        /// </summary>
        /// <returns>Redirected page</returns>
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Add validation errors to ModelState
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
