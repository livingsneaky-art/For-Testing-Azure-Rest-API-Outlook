using Basecode.Services.Interfaces;
using Basecode.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JobOpening jobOpening)
        {
            if (ModelState.IsValid)
            {
                string createdBy = "dummy1";
                _jobOpeningService.Create(jobOpening, createdBy);
                return RedirectToAction("Index");
            }

            return View(jobOpening);
        }
    }
}
