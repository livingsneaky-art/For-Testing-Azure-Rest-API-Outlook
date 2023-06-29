using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class LoginController : Controller
    {
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
