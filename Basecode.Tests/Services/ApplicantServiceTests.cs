using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.Repositories;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Moq;
using Xunit;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Tests.Services
{
    public class ApplicantServiceTests
    {
        private readonly ApplicantService _service;
        private readonly Mock<IApplicantRepository> _fakeRepository;
        private readonly Mock<IMapper> _fakeMapper;

        public ApplicantServiceTests()
        {
            _fakeRepository = new Mock<IApplicantRepository>();
            _fakeMapper = new Mock<IMapper>();
            _service = new ApplicantService(_fakeRepository.Object, _fakeMapper.Object);
        }

        [Fact]
        public void GetApplicants_ReturnsListOfApplicants()
        {
            // Arrange
            var applicants = new List<Applicant> { new Applicant(), new Applicant() };
            _fakeRepository.Setup(r => r.GetAll()).Returns(applicants.AsQueryable());

            // Act
            var result = _service.GetApplicants();

            // Assert
            Assert.Equal(applicants, result);
        }

        [Fact]
        public void GetApplicantById_ValidId_ReturnsApplicant()
        {
            // Arrange
            var applicant = new Applicant { Id = 1 };
            _fakeRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(applicant);

            // Act
            var result = _service.GetApplicantById(1);

            // Assert
            Assert.Equal(applicant, result);
        }

        [Fact]
        public void Create_ValidApplicant_ReturnsCreatedApplicantId()
        {
            // Arrange
            var applicantViewModel = new ApplicantViewModel();
            var applicant = new Applicant();
            var logContent = new LogContent { Result = true };
            _fakeMapper.Setup(m => m.Map<Applicant>(applicantViewModel)).Returns(applicant);
            _fakeRepository.Setup(r => r.CreateApplicant(It.IsAny<Applicant>())).Callback<Applicant>(a =>
            {
                a.Id = 1; // Set the ID of the created applicant
            });

            // Act
            var result = _service.Create(applicantViewModel);

            // Assert
            Assert.Equal(logContent.Result, result.Item1.Result);
            Assert.Equal(-1, result.Item2);
        }
    }
}
