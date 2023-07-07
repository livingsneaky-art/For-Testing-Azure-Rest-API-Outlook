using Basecode.Services.Interfaces;
using Basecode.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
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

        [Fact]
        public void Index_VisitLoginPage_ShowScreen()
        {

            //Act
            var result = _controller.Index();
            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
