using Basecode.WebApp.Controllers;
using Basecode.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Newtonsoft.Json;

namespace Basecode.Tests.Controllers
{
    public class ConfirmationControllerTests
    {
        private readonly ConfirmationController _controller;

        public ConfirmationControllerTests()
        {
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            _controller = new ConfirmationController { TempData = tempData };
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index("", "", "", "", "", "", "", "", "", "", "", "", "", new List<ReferenceModel>()) as ViewResult;

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_SetsTempData_ReturnsViewResult()
        {
            // Arrange
            var references = new List<ReferenceModel>()
            {
                new ReferenceModel { Name = "John Doe", Address = "123 Street", Email = "john@example.com" },
                new ReferenceModel { Name = "Jane Smith", Address = "456 Avenue", Email = "jane@example.com" }
            };

            // Act
            var result = _controller.Index("John", "Middle", "Doe", "1990-01-01", "30", "Male", "US",
                "123 Street", "City", "Province", "1234", "555-1234", "test@example.com", references) as ViewResult;

            // Assert
            Assert.Equal("John", _controller.TempData["First Name"]);
            Assert.Equal("Middle", _controller.TempData["Middle Name"]);
            Assert.Equal("Doe", _controller.TempData["Last Name"]);
            Assert.Equal("1990-01-01", _controller.TempData["Birthdate"]);
            Assert.Equal("30", _controller.TempData["Age"]);
            Assert.Equal("Male", _controller.TempData["Gender"]);
            Assert.Equal("US", _controller.TempData["Nationality"]);
            Assert.Equal("123 Street, City, Province 1234", _controller.TempData["Street"] + ", " + _controller.TempData["City"] + ", " + _controller.TempData["Province"] + " " + _controller.TempData["Zip"]);
            Assert.Equal("555-1234", _controller.TempData["Phone"]);
            Assert.Equal("test@example.com", _controller.TempData["Email"]);

            var referencesJson = _controller.TempData["ReferencesJson"] as string;
            var deserializedReferences = JsonConvert.DeserializeObject<List<ReferenceModel>>(referencesJson);
            Assert.Equal(2, deserializedReferences.Count);
            Assert.Equal("John Doe", deserializedReferences[0].Name);
            Assert.Equal("123 Street", deserializedReferences[0].Address);
            Assert.Equal("john@example.com", deserializedReferences[0].Email);
            Assert.Equal("Jane Smith", deserializedReferences[1].Name);
            Assert.Equal("456 Avenue", deserializedReferences[1].Address);
            Assert.Equal("jane@example.com", deserializedReferences[1].Email);
            Assert.IsType<ViewResult>(result);
        }
    }
}
