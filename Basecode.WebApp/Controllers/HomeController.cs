using Basecode.Main.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Basecode.Services.Interfaces;

namespace Basecode.Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobOpeningService _jobOpeningService;

        public HomeController(IJobOpeningService jobOpeningService)
        {
            _jobOpeningService = jobOpeningService;
        }
        /// <summary>
        /// Redirect to Home page when clicking Home in Nav Bar
        /// </summary>
        /// <returns>Redirected page</returns>
        public IActionResult Index()
        {
            var jobOpenings = _jobOpeningService.GetJobs();
            return View(jobOpenings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}