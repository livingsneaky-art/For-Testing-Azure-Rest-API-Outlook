using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly IJobOpeningService _jobOpeningService;
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="jobOpeningService">The job opening service.</param>
        /// <param name="applicantService">The applicant service.</param>
        public ApplicationService(IApplicationRepository repository, IMapper mapper, IJobOpeningService jobOpeningService, IApplicantService applicantService)
        {
            _repository = repository;
            _jobOpeningService = jobOpeningService;
            _applicantService = applicantService;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        public void Create(Application application)
        {
            _repository.CreateApplication(application);
        }

        /// <summary>
        /// Retrieves an application by its ID.
        /// </summary>
        /// <param name="id">The ID of the application to retrieve.</param>
        /// <returns>
        /// The application with the specified ID, or null if not found.
        /// </returns>
        public ApplicationViewModel? GetById(Guid id)
        {
            var application = _repository.GetById(id);

            if (application == null)
            {
                return null;
            }

            var job = _jobOpeningService.GetById(application.JobOpeningId);
            var applicant = _applicantService.GetApplicantById(application.ApplicantId);
            var data = new ApplicationViewModel
            {
                Id = application.Id,
                ApplicantName = applicant.Firstname + " " + applicant.Lastname,
                JobOpeningTitle = job.Title,
                Status = application.Status,
                UpdateTime = application.UpdateTime
            };

            return data;
        }

        /// <summary>
        /// Updates the specified application.
        /// </summary>
        /// <param name="application">The application.</param>
        public void Update(Application application)
        {
            var existingApplication = _repository.GetById(application.Id);
            
            existingApplication.Status = application.Status;
            existingApplication.UpdateTime = DateTime.Now;

            _repository.UpdateApplication(existingApplication);
        }
    }
}