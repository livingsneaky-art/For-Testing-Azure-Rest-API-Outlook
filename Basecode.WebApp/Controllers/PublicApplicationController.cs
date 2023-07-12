using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Basecode.WebApp.Controllers
{
    public class PublicApplicationController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IJobOpeningService _jobOpeningService;
        private readonly ICharacterReferenceService _characterReferenceService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public PublicApplicationController(IApplicantService applicantService, IJobOpeningService jobOpeningService, ICharacterReferenceService characterReferenceService)
        {
            _applicantService = applicantService;
            _characterReferenceService = characterReferenceService;
            _jobOpeningService = jobOpeningService;
        }

        /// <summary>
        /// Displays the index view for public applications.
        /// </summary>
        /// <returns>The index view.</returns>
        [HttpGet("/PublicApplication/Index/{jobOpeningId}")]
        public IActionResult Index(int jobOpeningId)
        {
            try
            {
                TempData["jobOpeningId"] = jobOpeningId;
                var model = new ApplicantViewModel();
                _logger.Trace("Successfuly renders form.");
                return View(model);
            }
            catch (Exception e)
            {
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return StatusCode(500, "Something went wrong.");
            }
        }

        public IActionResult Reference(string firstname,
                                       string middlename,
                                       string lastname,
                                       string age,
                                       string birthdate,
                                       string gender,
                                       string nationality,
                                       string street,
                                       string city,
                                       string province,
                                       string zip,
                                       string phone,
                                       string email,
                                       int jobId,
                                       IFormFile fileUpload)
        {
            try
            {
                if (fileUpload != null)
                {
                    string fileExtension = Path.GetExtension(fileUpload.FileName);
                    if (fileExtension != ".pdf")
                    {
                        TempData["ErrorMessage"] = "Only PDF files are allowed.";
                        return RedirectToAction("Index", new { jobOpeningId = jobId });
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        fileUpload.CopyTo(memoryStream);
                        byte[] fileData = memoryStream.ToArray();
                        TempData["FileData"] = fileData;
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Please select a file.";
                    return RedirectToAction("Index", new { jobOpeningId = jobId });
                }
                TempData["FileName"] = Path.GetFileName(fileUpload.FileName);

                var model = new ApplicantViewModel
                {
                    Firstname = firstname,
                    Middlename = middlename,
                    Lastname = lastname,
                    Age = Convert.ToInt32(age),
                    Birthdate = DateTime.Parse(birthdate),
                    Gender = gender,
                    Nationality = nationality,
                    Street = street,
                    City = city,
                    Province = province,
                    Zip = zip,
                    Phone = phone,
                    Email = email,
                    JobOpeningId = jobId
                };
                _logger.Trace("Successfuly renders form.");
                return View(model);
            }
            catch (Exception e)
            {
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return StatusCode(500, "Something went wrong.");
            }
        }

        public IActionResult Confirmation(string firstname,
                                          string middlename,
                                          string lastname,
                                          string age,
                                          string birthdate,
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
                                          List<CharacterReferenceViewModel> characterReferences)
        {
            try
            {
                TempData["FileName"] = fileName;
                TempData["FileData"] = fileData;
                var model = new ApplicantViewModel
                {
                    Firstname = firstname,
                    Middlename = middlename,
                    Lastname = lastname,
                    Age = Convert.ToInt32(age),
                    Birthdate = DateTime.Parse(birthdate),
                    Gender = gender,
                    Nationality = nationality,
                    Street = street,
                    City = city,
                    Province = province,
                    Zip = zip,
                    Phone = phone,
                    Email = email,
                    CV = fileData,
                    CharacterReferences = characterReferences,
                    JobOpeningId = jobId
                };
                _logger.Trace("Successfuly renders form.");
                return View(model);
            }
            catch (Exception e)
            {
                _logger.Error(ErrorHandling.DefaultException(e.Message));
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPost]
        public IActionResult Create(string firstname,
                                    string middlename,
                                    string lastname,
                                    string age,
                                    string birthdate,
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
                                    List<CharacterReferenceViewModel> characterReferences)
        {
            try
            {
                var applicant = new ApplicantViewModel
                {
                    Firstname = firstname,
                    Middlename = middlename,
                    Lastname = lastname,
                    Age = Convert.ToInt32(age),
                    Birthdate = DateTime.Parse(birthdate),
                    Gender = gender,
                    Nationality = nationality,
                    Street = street,
                    City = city,
                    Province = province,
                    Zip = zip,
                    Phone = phone,
                    Email = email,
                    CV = fileData,
                    CharacterReferences = characterReferences,
                    JobOpeningId = jobId
                };
                var isJobOpening = _jobOpeningService.GetById(applicant.JobOpeningId);
                if (isJobOpening != null)
                {
                    var data = _applicantService.Create(applicant);
                    if (!data.Result)
                    {
                        _logger.Trace("Create Applicant successfully.");
                        return RedirectToAction("Index", "Job");
                    }
                    _logger.Trace(ErrorHandling.SetLog(data));
                }
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
