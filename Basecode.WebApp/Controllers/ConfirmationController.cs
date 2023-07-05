using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class ConfirmationController : Controller
    {
        [HttpPost]
        public IActionResult Index(string name,
                            string birthdate,
                            string age,
                            string genderFinal,
                            string nationalityFinal,
                            string address,
                            string phone,
                            string email,
                            string referenceName,
                            string referenceAddress,
                            string referenceEmail)
        {
            // Store the name in TempData
            TempData["Name"] = name;

            // Store the birthdate in TempData
            TempData["Birthdate"] = birthdate;

            // Store the age in TempData
            TempData["Age"] = age;

            // Store the final gender in TempData
            TempData["Gender"] = genderFinal;

            // Store the final nationality in TempData
            TempData["Nationality"] = nationalityFinal;

            // Store the address in TempData
            TempData["Address"] = address;

            // Store the phone number in TempData
            TempData["Phone"] = phone;

            // Store the email address in TempData
            TempData["Email"] = email;

            // Store the reference name in TempData
            TempData["Reference Name"] = referenceName;

            // Store the reference address in TempData
            TempData["Reference Address"] = referenceAddress;

            // Store the reference email address in TempData
            TempData["Reference Email"] = referenceEmail;

            // Return a View result
            return View();
        }
    }
}
