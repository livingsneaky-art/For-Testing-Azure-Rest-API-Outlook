using Basecode.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Basecode.Tests.Controllers
{
    public class PublicApplicationControllerTests
    {
        private readonly PublicApplicationController _controller;

        public PublicApplicationControllerTests() 
        {
            _controller = new PublicApplicationController();
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
