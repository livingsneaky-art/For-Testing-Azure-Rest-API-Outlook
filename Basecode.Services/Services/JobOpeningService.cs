using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basecode.Services.Services
{
    public class JobOpeningService : ErrorHandling, IJobOpeningService
    {
        private readonly IJobOpeningRepository _repository;
        private readonly IQualificationService _qualificationService;
        private readonly IResponsibilityService _responsibilityService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobOpeningService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="qualificationService">The qualification service.</param>
        /// <param name="responsibilityService">The responsibility service.</param>
        public JobOpeningService(IJobOpeningRepository repository, IMapper mapper, IQualificationService qualificationService, IResponsibilityService responsibilityService)
        {
            _repository = repository;
            _mapper = mapper;
            _qualificationService = qualificationService;
            _responsibilityService = responsibilityService;
        }

        /// <summary>
        /// Gets a list of all job openings.
        /// </summary>
        /// <returns>
        /// A list of job opening view models.
        /// </returns>
        public List<JobOpeningViewModel> GetJobs()
        {
            var data = _repository.GetAll().Select(m => new JobOpeningViewModel
            {
                Id = m.Id,
                Title = m.Title,
                EmploymentType = m.EmploymentType,
                WorkSetup = m.WorkSetup,
                Location = m.Location,
                Category = m.Category
            }).ToList();

            return data;
        }

        /// <summary>
        /// Creates a new job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to create.</param>
        /// <param name="createdBy">The user who created the job opening.</param>
        ///<response code="400">JobOpening details are invalid</response>
        ///<response code="201">JobOpening created successfully</response>
        public LogContent Create(JobOpeningViewModel jobOpening, string createdBy)
        {
            LogContent logContent = new LogContent();

            if (string.IsNullOrEmpty(jobOpening.Title) || jobOpening.Title.Length > 50)
            {
                logContent.Result = false;
                logContent.ErrorCode = "400";
                logContent.Message = "Title length is 0 or more than 50 characters.";
            }
            else
            {
                logContent.Result = false;
                logContent.ErrorCode = "201";
                logContent.Message = "Create JobOpening succesfully.";
                var jobOpeningModel = _mapper.Map<JobOpening>(jobOpening);

                jobOpeningModel.CreatedBy = createdBy;
                jobOpeningModel.CreatedTime = DateTime.Now;
                jobOpeningModel.UpdatedBy = createdBy;
                jobOpeningModel.UpdatedTime = DateTime.Now;

                _repository.AddJobOpening(jobOpeningModel);
            }
            return logContent;
        }


        /// <summary>
        /// Gets a job opening by its ID.
        /// </summary>
        /// <param name="id">The ID of the job opening to get.</param>
        /// <returns>
        /// A job opening view model, or null if no such job opening exists.
        /// </returns>
        public JobOpeningViewModel GetById(int id)
        {
            var qualifications = _qualificationService.GetQualificationsByJobOpeningId(id);
            var responsibilities = _responsibilityService.GetResponsibilitiesByJobOpeningId(id);
            var data = _repository.GetAll().Where(m => m.Id == id).Select(m => new JobOpeningViewModel
            {
                Id = m.Id,
                Title = m.Title,
                EmploymentType = m.EmploymentType,
                WorkSetup = m.WorkSetup,
                Location = m.Location,
                Category = m.Category,
                Responsibilities = responsibilities,
                Qualifications = qualifications
            }).FirstOrDefault();

            return data;
        }


        /// <summary>
        /// Updates an existing job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to update.</param>
        /// <param name="updatedBy">The user who updated the job opening.</param>
        public void Update(JobOpeningViewModel jobOpening, string updatedBy)
        {
            var jobExisting = _repository.GetJobOpeningById(jobOpening.Id);
            _mapper.Map(jobOpening, jobExisting);
            jobExisting.UpdatedBy = updatedBy;
            jobExisting.UpdatedTime = DateTime.Now;

            _repository.UpdateJobOpening(jobExisting);
        }

        /// <summary>
        /// Deletes a job opening.
        /// </summary>
        /// <param name="jobOpening">The job opening to delete.</param>
        public void Delete(JobOpeningViewModel jobOpening)
        {
            var job = new JobOpening
            {
                Id = jobOpening.Id,
                Title = jobOpening.Title,
                EmploymentType = jobOpening.EmploymentType,
                WorkSetup = jobOpening.WorkSetup,
                Location = jobOpening.Location,
                Category = jobOpening.Category
            };

            _repository.DeleteJobOpening(job);
        }

    }
}
