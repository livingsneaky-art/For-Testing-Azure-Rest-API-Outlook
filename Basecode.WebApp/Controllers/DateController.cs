using Basecode.Main.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Basecode.Services.Interfaces;
using NLog;
using Basecode.Data.ViewModels;
using Basecode.Services.Services;
using Microsoft.IdentityModel.Tokens;

namespace Basecode.Main.Controllers
{
    public class DateController : Controller
    {
        
        public IActionResult Index()
        {
            
                return View();
            
        }
    }
}