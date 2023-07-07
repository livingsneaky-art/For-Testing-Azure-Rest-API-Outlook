using Basecode.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace Basecode.WebApp.Controllers
{
    public class ConfirmationController : Controller
    {
        /// <summary>
        /// Stores data from the inputs of the user for their personal information and character references in the public application form.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthdate"></param>
        /// <param name="age"></param>
        /// <param name="genderFinal"></param>
        /// <param name="nationalityFinal"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="references"></param>
        /// <returns>View of the Confirmation of Public Application Form Page</returns>
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
    }
}