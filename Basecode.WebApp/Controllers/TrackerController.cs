using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class TrackerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
