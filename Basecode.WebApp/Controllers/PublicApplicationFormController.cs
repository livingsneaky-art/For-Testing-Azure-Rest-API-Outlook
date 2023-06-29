using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class PublicApplicationFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
