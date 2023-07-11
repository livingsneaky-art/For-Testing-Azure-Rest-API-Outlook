using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System.IO;

namespace Basecode.WebApp.Controllers
{
    public class ConfirmationController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly ICharacterReferenceService _characterReferenceService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationController"/> class.
        /// </summary>
        /// <param name="applicantService">The applicant service.</param>
        /// <param name="characterReferenceService">The character reference service.</param>
        public ConfirmationController(IApplicantService applicantService, ICharacterReferenceService characterReferenceService)
        {
            _applicantService = applicantService;
            _characterReferenceService = characterReferenceService;
        }

        /// <summary>
        /// Displays the confirmation page with the applicant and character reference data.
        /// </summary>
        /// <param name="firstName">The first name of the applicant.</param>
        /// <param name="middleName">The middle name of the applicant.</param>
        /// <param name="lastName">The last name of the applicant.</param>
        /// <param name="birthdate">The birthdate of the applicant.</param>
        /// <param name="age">The age of the applicant.</param>
        /// <param name="gender">The gender of the applicant.</param>
        /// <param name="nationality">The nationality of the applicant.</param>
        /// <param name="street">The street address of the applicant.</param>
        /// <param name="city">The city of the applicant.</param>
        /// <param name="province">The province of the applicant.</param>
        /// <param name="zip">The zip code of the applicant.</param>
        /// <param name="phone">The phone number of the applicant.</param>
        /// <param name="email">The email address of the applicant.</param>
        /// <param name="references">The list of character references.</param>
        /// <returns>The view result.</returns>
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
                            string fileName,
                            byte[] fileData,
                            List<CharacterReferenceViewModel> references)
        {
            string referencesJson = JsonConvert.SerializeObject(references);

            TempData["FileData"] = fileData;
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
            TempData["FileName"] = fileName;
            TempData["ReferencesJson"] = referencesJson;

            return View();
        }

        /// <summary>
        /// Creates the applicant and character references based on the submitted data.
        /// </summary>
        /// <param name="applicant">The ApplicantViewModel object containing the applicant data.</param>
        /// <param name="references">The list of CharacterReferenceViewModel objects containing the character reference data.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        public IActionResult Create(ApplicantViewModel applicant, List<CharacterReferenceViewModel> references)
        {
            try
            {
                var (data, createdApplicantId) = _applicantService.Create(applicant);

                if (!data.Result)
                {
                    _logger.Trace("Create Applicant successfully.");

                    foreach (var characterReference in references)
                    {
                        var logContent = _characterReferenceService.Create(characterReference, createdApplicantId);

                        if (logContent.Result == false)
                        {
                            _logger.Trace("Create Character Reference successfully.");
                        }
                        else
                        {
                            _logger.Trace(ErrorHandling.SetLog(logContent));
                        }
                    }
                    return RedirectToAction("Index", "Job");
                }
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