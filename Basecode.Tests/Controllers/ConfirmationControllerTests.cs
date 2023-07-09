using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Tests.Controllers
{
    public class ConfirmationControllerTests
    {
        private readonly Mock<IApplicantService> _fakeApplicantService;
        private readonly Mock<ICharacterReferenceService> _fakeCharacterReferenceService;
        private readonly ConfirmationController _controller;

        public ConfirmationControllerTests()
        {
            _fakeApplicantService = new Mock<IApplicantService>();
            _fakeCharacterReferenceService = new Mock<ICharacterReferenceService>();
            _controller = new ConfirmationController(_fakeApplicantService.Object, _fakeCharacterReferenceService.Object);
        }

        [Fact]
        public void Index_WithData_ReturnsViewResult()
        {
            // Arrange
            var tempData = new Mock<ITempDataDictionary>();
            _controller.TempData = tempData.Object;
            List<CharacterReferenceViewModel> references = new List<CharacterReferenceViewModel>();

            // Act
            var result = _controller.Index("John", "Middle", "Doe", "2000-01-01", "21", "Male", "US", "Street", "City", "State", "12345", "1234567890", "test@example.com", references);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void Create_ValidData_RedirectsToIndexActionInJobController()
        {
            // Arrange
            var applicant = new ApplicantViewModel();
            var references = new List<CharacterReferenceViewModel>();

            _fakeApplicantService.Setup(s => s.Create(It.IsAny<ApplicantViewModel>()))
                .Returns((new LogContent { Result = true }, 1));

            _fakeCharacterReferenceService.Setup(s => s.Create(It.IsAny<CharacterReferenceViewModel>(), It.IsAny<int>()))
                .Returns(new LogContent { Result = false });

            // Act
            var result = _controller.Create(applicant, references);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }

        [Fact]
        public void Create_ExceptionOccurs_ReturnsStatusCode500()
        {
            // Arrange
            var applicant = new ApplicantViewModel();
            var references = new List<CharacterReferenceViewModel>();

            _fakeApplicantService.Setup(s => s.Create(It.IsAny<ApplicantViewModel>()))
                .Throws(new Exception("Something went wrong."));

            // Act
            var result = _controller.Create(applicant, references) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
    }
}
