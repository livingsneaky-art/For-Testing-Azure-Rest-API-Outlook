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
        public async Task<IActionResult> Login()
        {
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
