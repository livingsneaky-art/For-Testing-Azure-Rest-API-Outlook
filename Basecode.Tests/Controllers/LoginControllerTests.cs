using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Moq;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

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
        public void Index_VisitLoginPageSuccess_ShowScreen()
        {
            //Act
            var result = _controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
        
        [Fact]
        public void Login_InputIsValid_RedirectToDashboard()
        {
            //Arrange
            var loginVM = new LoginViewModel
            {
                Email = "user1@gmail.com",
                Password = "password1",
            };

            //Act
            var result = _controller.Login(loginVM) as RedirectToActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Dashboard", result.ControllerName);
        }

        [Fact]
        public void Login_InputIsNotValid_RedirectToIndex()
        {
            //Arrange
            var loginVM = new LoginViewModel
            {
                Email = "",
                Password = "",
            };
            _controller.ModelState.AddModelError("Email", "Email is required");
            _controller.ModelState.AddModelError("Password", "Password is required");

            //Act
            var result = _controller.Login(loginVM) as RedirectToActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", result.ActionName);
        }

    }
}
