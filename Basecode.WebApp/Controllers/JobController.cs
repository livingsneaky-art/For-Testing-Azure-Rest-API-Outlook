using Basecode.Services.Interfaces;
using Basecode.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Basecode.Data.ViewModels;

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

        public IActionResult CreateView()
        {
            return View();
        }

        public IActionResult JobView(int id)
        {
            var jobOpening = _jobOpeningService.GetById(id);
            if (jobOpening == null)
            {
                return NotFound();
            }

            return View(jobOpening);
        }

        [HttpPost]
        public IActionResult Create(JobOpening jobOpening)
        {
            string createdBy = "dummy_person";
            _jobOpeningService.Create(jobOpening, createdBy);
            return RedirectToAction("Index");

        }

        public IActionResult UpdateView(int id)
        {
            var jobOpening = _jobOpeningService.GetById(id);
            if (jobOpening == null)
            {
                return NotFound();
            }

            return View(jobOpening);
        }

        [HttpPost]
        public IActionResult Update(JobOpeningViewModel jobOpening)
        {
            if (ModelState.IsValid)
            {
                string updatedBy = "dummy1";
                _jobOpeningService.Update(jobOpening, updatedBy);
                return RedirectToAction("Index");
            }

            return View(jobOpening);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var jobOpening = _jobOpeningService.GetById(id);
            if (jobOpening == null)
            {
                return NotFound();
            }

            _jobOpeningService.Delete(jobOpening);
            return RedirectToAction("Index");
        }
    }
}
