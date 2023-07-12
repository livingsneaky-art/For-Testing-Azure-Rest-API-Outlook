using Basecode.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class PublicApplicationController : Controller
    {
        /// <summary>
        /// Displays the index view for public applications.
        /// </summary>
        /// <returns>The index view.</returns>
        [HttpGet("/PublicApplication/Index/{jobOpeningId}")]
        public IActionResult Index(int jobOpeningId)
        {
            TempData["jobOpeningId"] = jobOpeningId;
            return View();
        }

        public IActionResult Reference()
        {
            return View();
        }
    }
}
