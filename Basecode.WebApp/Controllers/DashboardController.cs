using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NLog;

namespace Basecode.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IApplicantService _applicantService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardController"/> class.
        /// </summary>
        /// <param name="applicantService">The applicant service.</param>
        public DashboardController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
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
    }
}
