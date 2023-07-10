using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Basecode.WebApp.Controllers
{
    public class ReferenceController : Controller
    {
        /// <summary>
        /// Handles the submission of a character reference form.
        /// </summary>
        /// <param name="firstName">The first name of the character reference.</param>
        /// <param name="middleName">The middle name of the character reference.</param>
        /// <param name="lastName">The last name of the character reference.</param>
        /// <param name="date">The birthdate of the character reference.</param>
        /// <param name="age">The age of the character reference.</param>
        /// <param name="gender">The gender of the character reference.</param>
        /// <param name="nationality">The nationality of the character reference.</param>
        /// <param name="street">The street address of the character reference.</param>
        /// <param name="city">The city of the character reference.</param>
        /// <param name="province">The province of the character reference.</param>
        /// <param name="zip">The zip code of the character reference.</param>
        /// <param name="phone">The phone number of the character reference.</param>
        /// <param name="email">The email address of the character reference.</param>
        /// <returns>The view result.</returns>
        [HttpPost]
        public IActionResult Index(string firstName,
                            string middleName,
                            string lastName,
                            string date,
                            string age,
                            string gender,
                            string nationality,
                            string street,
                            string city,
                            string province,
                            string zip,
                            string phone,
                            string email)
        {
            TempData["First Name"] = firstName;
            TempData["Middle Name"] = middleName;
            TempData["Last Name"] = lastName;
            TempData["Birthdate"] = date;
            TempData["Age"] = age;
            TempData["Gender"] = gender;
            TempData["Nationality"] = nationality;
            TempData["Street"] = street;
            TempData["City"] = city;
            TempData["Province"] = province;
            TempData["Zip"] = zip;
            TempData["Phone"] = phone;
            TempData["Email"] = email;
            return View();
        }
    }
}