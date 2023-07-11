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
                            string email,
                            IFormFile fileUpload)
        {
            if (fileUpload != null)
            {
                string fileExtension = Path.GetExtension(fileUpload.FileName);
                if (fileExtension != ".pdf")
                {
                    TempData["ErrorMessage"] = "Only PDF files are allowed.";
                    return RedirectToAction("Index", "PublicApplication");
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
                return RedirectToAction("Index", "PublicApplication");
            }

            TempData["FileName"] = Path.GetFileName(fileUpload.FileName);
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