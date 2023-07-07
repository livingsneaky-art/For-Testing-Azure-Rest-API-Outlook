using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Basecode.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System.Diagnostics;
using System.Net;

namespace Basecode.WebApp.Controllers
{
    public class ConfirmationController : Controller
    {
        private readonly IApplicantService _applicantService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ConfirmationController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        /// <summary>
        /// Stores input data from Personal Information and Character References.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthdate"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="nationality"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="province"></param>
        /// <param name="zip"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="references"></param>
        /// <returns>View of the Confirmation Page</returns>
        [HttpPost]
        public IActionResult Index(string firstName,
                            string middleName,
                            string lastName,
                            string birthdate,
                            string age,
                            string gender,
                            string nationality,
                            string street,
                            string city,
                            string province,
                            string zip,
                            string phone,
                            string email,
                            List<ReferenceModel> references)
        {
            TempData["First Name"] = firstName;
            TempData["Middle Name"] = middleName;
            TempData["Last Name"] = lastName;
            TempData["Birthdate"] = birthdate;
            TempData["Age"] = age;
            TempData["Gender"] = gender;
            TempData["Nationality"] = nationality;
            TempData["Street"] = street;
            TempData["City"] = city;
            TempData["Province"] = province;
            TempData["Zip"] = zip;
            TempData["Phone"] = phone;
            TempData["Email"] = email;
            string referencesJson = JsonConvert.SerializeObject(references);
            TempData["ReferencesJson"] = referencesJson;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ApplicantViewModel applicant)
        {
            try
            {
                var data = _applicantService.Create(applicant);
                //Checks for any validation warning
                if (!data.Result)
                {
                    _logger.Trace("Create Applicant succesfully.");
                    return RedirectToAction("Index", "Job");
                }
                //Fails the validation
                _logger.Trace(ErrorHandling.SetLog(data));
                return View("Index");
            }
            catch (Exception e)
            {
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return StatusCode(500, "Something went wrong.");
            }

        }
    }
}