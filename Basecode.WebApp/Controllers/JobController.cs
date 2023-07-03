using Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobOpeningService _jobOpeningService;

        public JobController(IJobOpeningService jobOpeningService)
        {
            _jobOpeningService = jobOpeningService;
        }

        public IActionResult Index()
        {
            var jobOpenings = _jobOpeningService.GetJobs();
            return View(jobOpenings);
        }
    }
}
