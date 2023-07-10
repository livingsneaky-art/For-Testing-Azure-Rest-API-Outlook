using Basecode.WebApp.Controllers;
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
            _controller = new ReferenceController();
        }

        [Fact]
        public void Index_ValidInput_ReturnsViewResult()
        {
            // Arrange
            var tempData = new Mock<ITempDataDictionary>();
            _controller.TempData = tempData.Object;

            string firstName = "John";
            string middleName = "Doe";
            string lastName = "Smith";
            string date = "1990-01-01";
            string age = "33";
            string gender = "Male";
            string nationality = "American";
            string street = "123 Main St";
            string city = "New York";
            string province = "NY";
            string zip = "10001";
            string phone = "1234567890";
            string email = "john@example.com";

            // Act
            var result = _controller.Index(firstName, middleName, lastName, date, age, gender, nationality,
                street, city, province, zip, phone, email);

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
