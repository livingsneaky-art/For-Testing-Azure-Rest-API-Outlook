using Basecode.Services.Interfaces;
using Basecode.WebApp.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Tests.Controllers
{
    public class LoginControllerTests
    {
        private readonly LoginController _controller;

        public LoginControllerTests()
        {
            _controller = new LoginController();
        }
    }
}
