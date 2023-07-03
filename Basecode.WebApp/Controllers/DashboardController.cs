using Basecode.Data.Models;
using Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IApplicantService _applicantService;

        public DashboardController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        public IActionResult Index()
        {
            List<Applicant> applicants = _applicantService.GetApplicants();
            return View(applicants);
        }
    }
}
