using Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class TrackerController : Controller
    {
        private readonly IApplicationService _applicationService;

        public TrackerController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetApplicationById(Guid id)
        {
            var application = _applicationService.GetById(id);
            if (application != null)
            {
                return Json(new { success = true, data = application });
            }
            else
            {
                return Json(new { success = false, message = "Application not found." });
            }
        }
    }
}
