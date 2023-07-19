using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System.Globalization;

namespace Basecode.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IApplicantService _applicantService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IApplicationService _applicationService;
        private readonly IHrScheduler _hrScheduler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardController"/> class.
        /// </summary>
        /// <param name="applicantService">The applicant service.</param>
        public DashboardController(IApplicantService applicantService, IHrScheduler hrScheduler, IApplicationService applicationService)
        {
            _applicantService = applicantService;
            _hrScheduler = hrScheduler;
            _applicationService = applicationService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            try
            {
                var applicants = _applicantService.GetApplicant();
                if(applicants.IsNullOrEmpty())
                {
                    _logger.Trace("Applicant List is null or empty.");
                    return View(applicants);
                }
                _logger.Trace("Applicants List is rendered successfully.");

                // Convert the Applicant model to ApplicantViewModel
                //List<ApplicantViewModel> applicantViewModels = applicants.Select(applicant => new ApplicantViewModel
                //{
                //    Id = applicant.Id,
                //    Firstname = applicant.Firstname,
                //    // Map other properties as needed
                //}).ToList();

                return View(applicants);
            }
            catch (Exception e)
            {
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPost]
        public IActionResult ScheduleInterview(string interviewerName, string interviewerEmail,
                                           string applicantName, string applicantEmail,
                                           DateTime interviewDate, string interviewLocation)
        {
            _hrScheduler.ScheduleInterview(interviewerName, interviewerEmail, applicantName,
                                           applicantEmail, interviewDate, interviewLocation);

            // Any other logic you need

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public IActionResult UpdateApplicantUpdateTime(int applicantId, DateTime updateTime)
        {
            try
            {
                // Fetch the applicant from the database based on the applicantId
                var application = _applicationService.GetApplicationsById(applicantId);
                var applicant = _applicantService.GetApplicantById(applicantId);
                

                if (application != null)
                {
                    // Update the applicant's UpdateTime property
                    application.UpdateTime = updateTime;

                    // Save the changes to the database
                    _applicationService.UpdateApplication(application);

                    _hrScheduler.ScheduleInterview("N to fetch assigned Interviewer", "hrautomatesystem@outlook.com", applicant.Firstname,
                                           applicant.Email, application.UpdateTime, "N to fetch JobOpening location");

                    // If the update is successful, return a JSON response indicating success
                    return Json(new { success = true });
                }
                else
                {
                    // If the applicant is not found, return a JSON response indicating failure
                    return Json(new { success = false, message = "Applicant not found." });
                }
            }
            catch (Exception e)
            {
                // Log the error and return a JSON response indicating failure
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return Json(new { success = false, message = "Something went wrong." });
            }
        }
    }
}
