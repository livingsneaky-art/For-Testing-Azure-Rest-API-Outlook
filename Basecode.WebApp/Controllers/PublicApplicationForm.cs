using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class PublicApplicationForm : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
