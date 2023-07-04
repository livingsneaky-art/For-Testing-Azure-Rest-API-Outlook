using Microsoft.AspNetCore.Mvc;

namespace Basecode.WebApp.Controllers
{
    public class ConfirmationFormController : Controller
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
            TempData["Name"] = name;
            TempData["Birthdate"] = birthdate;
            TempData["Age"] = age;
            TempData["Gender"] = genderFinal;
            TempData["Nationality"] = nationalityFinal;
            TempData["Address"] = address;
            TempData["Phone"] = phone;
            TempData["Email"] = email;
            TempData["Reference Name"] = referenceName;
            TempData["Reference Address"] = referenceAddress;
            TempData["Reference Email"] = referenceEmail;
            return View();
        }
    }
}
