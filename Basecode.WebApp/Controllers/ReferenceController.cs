using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class ReferenceController : Controller
    {
        /// <summary>
        /// Handles the HTTP POST request to submit the reference form.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="date"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="nationality"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="province"></param>
        /// <param name="zip"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="fileUpload"></param>
        /// <returns>The view to be rendered after the form submission.</returns>
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
            TempData["FileName"] = Path.GetFileName(fileUpload.FileName);

            return View();
        }
    }
}