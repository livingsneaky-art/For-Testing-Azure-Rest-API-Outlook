using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class PublicApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
