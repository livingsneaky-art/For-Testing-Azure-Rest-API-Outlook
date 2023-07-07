using Basecode.Main.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Basecode.Services.Interfaces;
using NLog;

namespace Basecode.Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobOpeningService _jobOpeningService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="jobOpeningService">The job opening service.</param>
        public HomeController(IJobOpeningService jobOpeningService)
        {
            _jobOpeningService = jobOpeningService;
        }

        /// <summary>
        /// Retrieves a list of job openings, category jobs and returns a view with the list.
        /// </summary>
        /// <returns>
        /// A view with a list of job openings and category of job.
        /// </returns>
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