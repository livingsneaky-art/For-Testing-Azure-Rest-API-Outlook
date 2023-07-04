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
                                   string email)
        {
            TempData["Name"] = name;
            TempData["Birthdate"] = birthdate;
            TempData["Age"] = age;
            TempData["Gender"] = genderFinal;
            TempData["Nationality"] = nationalityFinal;
            TempData["Address"] = address;
            TempData["Phone"] = phone;
            TempData["Email"] = email;
            return View();
        }
    }
}
