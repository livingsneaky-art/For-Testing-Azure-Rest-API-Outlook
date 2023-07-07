using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class PublicApplicationController : Controller
    {
        /// <summary>
        /// Starting page of Public Application Form
        /// </summary>
        /// <returns>View of Personal Information</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
