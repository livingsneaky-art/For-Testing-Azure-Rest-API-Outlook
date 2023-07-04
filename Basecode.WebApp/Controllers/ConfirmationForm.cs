using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class ConfirmationForm : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
