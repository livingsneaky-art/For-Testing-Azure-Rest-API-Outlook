using Basecode.WebApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace Basecode.Tests.Controllers
{
    public class ReferenceControllerTests
    {
        private readonly ReferenceController _controller;

        public ReferenceControllerTests()
        {
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            _controller = new ReferenceController { TempData = tempData };
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index("", "", "", "", "", "", "", "", "", "", "", "", "");

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_SetsTempData_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index("John", "Doe", "Smith", "2023-01-01", "30", "Male", "US",
                "123 Street", "City", "State", "12345", "555-1234", "test@example.com") as ViewResult;

            // Assert
            Assert.Equal("John Doe Smith", _controller.TempData["First Name"] + " " + _controller.TempData["Middle Name"] + " " + _controller.TempData["Last Name"]);
            Assert.Equal("2023-01-01", _controller.TempData["Birthdate"]);
            Assert.Equal("30", _controller.TempData["Age"]);
            Assert.Equal("Male", _controller.TempData["Gender"]);
            Assert.Equal("US", _controller.TempData["Nationality"]);
            Assert.Equal("123 Street, City, State 12345", _controller.TempData["Street"] + ", " + _controller.TempData["City"] + ", " + _controller.TempData["Province"] + " " + _controller.TempData["Zip"]);
            Assert.Equal("555-1234", _controller.TempData["Phone"]);
            Assert.Equal("test@example.com", _controller.TempData["Email"]);
            Assert.IsType<ViewResult>(result);
        }
    }
}
