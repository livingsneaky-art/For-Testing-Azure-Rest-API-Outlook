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
            TempData["Name"] = firstName + " " + middleName + " " + lastName;
            TempData["Birthdate"] = date;
            TempData["Age"] = age;
            TempData["Gender"] = gender;
            TempData["Nationality"] = nationality;
            TempData["Address"] = tempStreet + ", " + tempCity + ", " + tempProvince + " " + tempZip;
            TempData["Phone"] = tempPhone;
            TempData["Email"] = tempMail;
            return View();
        }
    }
}
