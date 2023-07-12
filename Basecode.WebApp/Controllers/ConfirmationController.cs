using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;

namespace Basecode.WebApp.Controllers
{
    public class ConfirmationController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IJobOpeningService _jobOpeningService;
        private readonly ICharacterReferenceService _characterReferenceService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationController"/> class.
        /// </summary>
        /// <param name="applicantService">The applicant service.</param>
        /// <param name="characterReferenceService">The character reference service.</param>
        public ConfirmationController(IApplicantService applicantService, IJobOpeningService jobOpeningService, ICharacterReferenceService characterReferenceService)
        {
            _applicantService = applicantService;
            _characterReferenceService = characterReferenceService;
            _jobOpeningService = jobOpeningService;
        }

        /// <summary>
        /// Renders the confirmation view with the submitted data.
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
        /// <param name="fileName"></param>
        /// <param name="fileData"></param>
        /// <param name="references"></param>
        /// <returns>The view to be rendered.</returns>
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
                            int jobId,
                            List<CharacterReferenceViewModel> references)
        {
            string referencesJson = JsonConvert.SerializeObject(references);

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
            TempData["FileData"] = fileData;
            TempData["FileName"] = fileName;
            TempData["ReferencesJson"] = referencesJson;
            TempData["JobOpeningId"] = jobId;

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

                var isJobOpening = _jobOpeningService.GetById(applicant.JobOpeningId);
                if (isJobOpening != null)
                {
                    var data = _applicantService.Create(applicant, references);

                }


                //if (!data.Result)
                //{
                //    _logger.Trace("Create Applicant successfully.");

                //    foreach (var characterReference in references)
                //    {
                //        var logContent = _characterReferenceService.Create(characterReference, createdApplicantId);

                //        if (logContent.Result == false)
                //        {
                //            _logger.Trace("Create Character Reference successfully.");
                //        }
                //        else
                //        {
                //            _logger.Trace(ErrorHandling.SetLog(logContent));
                //        }
                //    }
                //    return RedirectToAction("Index", "Job");
                //}
                //_logger.Trace(ErrorHandling.SetLog(data));
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