using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class CharacterReferenceFormController : Controller
    {
        [HttpPost]
        public IActionResult Index(string firstName,
                            string middleName,
                            string lastName,
                            string date,
                            string age,
                            string gender,
                            string nationality,
                            string tempStreet,
                            string tempCity,
                            string tempProvince,
                            string tempZip,
                            string tempPhone,
                            string tempMail)
        {
            // Store the concatenated full name in TempData
            TempData["Name"] = firstName + " " + middleName + " " + lastName;

            // Store the birthdate in TempData
            TempData["Birthdate"] = date;

            // Store the age in TempData
            TempData["Age"] = age;

            // Store the gender in TempData
            TempData["Gender"] = gender;

            // Store the nationality in TempData
            TempData["Nationality"] = nationality;

            // Concatenate the temporary address and store it in TempData
            TempData["Address"] = tempStreet + ", " + tempCity + ", " + tempProvince + " " + tempZip;

            // Store the temporary phone number in TempData
            TempData["Phone"] = tempPhone;

            // Store the temporary email address in TempData
            TempData["Email"] = tempMail;

            // Return a View result
            return View();
        }
    }
}
