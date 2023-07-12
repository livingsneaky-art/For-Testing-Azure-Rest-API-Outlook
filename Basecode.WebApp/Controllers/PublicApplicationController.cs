using Basecode.Data.ViewModels;
using Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Basecode.WebApp.Controllers
{
    public class PublicApplicationController : Controller
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

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
                                       string email)
        {
            try
            {
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
                    Email = email
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
                                          List<CharacterReferenceViewModel> characterReferences)
        {
            try
            {
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
                    CharacterReferences = characterReferences
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
    }
}
