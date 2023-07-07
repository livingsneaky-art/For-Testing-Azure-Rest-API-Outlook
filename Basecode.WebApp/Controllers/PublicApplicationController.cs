using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class PublicApplicationController : Controller
    {
        /// <summary>
        /// Displays the index view for public applications.
        /// </summary>
        /// <returns>The index view.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
