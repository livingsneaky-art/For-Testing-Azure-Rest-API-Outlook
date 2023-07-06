using Basecode.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

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
                            List<ReferenceModel> references)
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

            // Serialize the references list to JSON
            string referencesJson = JsonConvert.SerializeObject(references);

            // Store the references JSON in TempData
            TempData["ReferencesJson"] = referencesJson;

            // Return a View result
            return View();
        }
    }
}