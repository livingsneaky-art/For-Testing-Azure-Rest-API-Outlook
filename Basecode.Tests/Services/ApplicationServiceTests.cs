using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using Basecode.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Tests.Services
{
    public class ApplicationServiceTests
    {
        private readonly ApplicationService _service;
        private readonly Mock<IApplicationRepository> _fakeApplicationRepository;
        private readonly Mock<IJobOpeningService> _fakeJobOpeningService;
        private readonly Mock<IApplicantService> _fakeApplicantService;
        private readonly Mock<IMapper> _fakeMapper;

        public ApplicationServiceTests()
        {
            _fakeApplicationRepository = new Mock<IApplicationRepository>();
            _fakeJobOpeningService = new Mock<IJobOpeningService>();
            _fakeApplicantService = new Mock<IApplicantService>();
            _fakeMapper = new Mock<IMapper>();
            _service = new ApplicationService(_fakeApplicationRepository.Object, _fakeMapper.Object, _fakeJobOpeningService.Object, _fakeApplicantService.Object);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsApplicationViewModel()
        {
            // Arrange
            var id = new System.Guid("46f3c7fb-43e7-4a3e-8696-0e6e6cf1ccf3");
            var application = new Application
            {
                Id = id, 
                JobOpeningId = 1, 
                ApplicantId = 1, 
                Status = "For Screening",
                ApplicationDate = System.DateTime.Now,
                UpdateTime = System.DateTime.Now
            };
            var job = new JobOpeningViewModel
            {
                Id = 1, 
                Title = "Software Engineer" 
            };
            var applicant = new Applicant
            { 
                Id = 1, 
                Firstname = "John", 
                Lastname = "Doe" 
            };
            var applicationViewModel = new ApplicationViewModel
            {
                Id = application.Id,
                JobOpeningTitle = job.Title,
                ApplicantName = $"{applicant.Firstname} {applicant.Lastname}",
                Status = application.Status,
                UpdateTime = application.UpdateTime
            };

            _fakeApplicationRepository.Setup(repo => repo.GetById(id)).Returns(application);
            _fakeJobOpeningService.Setup(service => service.GetById(application.JobOpeningId)).Returns(job);
            _fakeApplicantService.Setup(service => service.GetApplicantById(application.ApplicantId)).Returns(applicant);
            _fakeMapper.Setup(mapper => mapper.Map<ApplicationViewModel>(application)).Returns(applicationViewModel);

            // Act
            var result = _service.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ApplicationViewModel>(result);
            Assert.Equal(applicationViewModel.Id, result.Id);
            Assert.Equal(applicationViewModel.ApplicantName, result.ApplicantName);
            Assert.Equal(applicationViewModel.JobOpeningTitle, result.JobOpeningTitle);
            Assert.Equal(applicationViewModel.Status, result.Status);
            Assert.Equal(applicationViewModel.UpdateTime, result.UpdateTime);
        }

        [Fact]
        public void GetById_NotExistingId_ReturnsNull()
        {
            // Arrange
            var id = new System.Guid("46f3c7fb-43e7-4a3e-8696-0e6e6cf1ccf3");
            Application nullApplication = null;

            _fakeApplicationRepository.Setup(repo => repo.GetById(id)).Returns(nullApplication);

            // Act
            var result = _service.GetById(id);

            // Assert
            Assert.Null(result);
        }
    }
}
