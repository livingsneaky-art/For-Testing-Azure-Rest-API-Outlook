using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
