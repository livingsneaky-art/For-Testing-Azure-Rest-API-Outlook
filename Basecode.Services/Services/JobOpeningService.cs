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
    public class JobOpeningService : IJobOpeningService
    {
        private readonly IJobOpeningRepository _repository;
        private readonly IQualificationService _qualificationService;
        private readonly IResponsibilityService _responsibilityService;
        private readonly IMapper _mapper;

        public JobOpeningService(IJobOpeningRepository repository, IMapper mapper, IQualificationService qualificationService, IResponsibilityService responsibilityService)
        {
            _repository = repository;
            _mapper = mapper;
            _qualificationService = qualificationService;
            _responsibilityService = responsibilityService;
        }

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

        public void Create(JobOpeningViewModel jobOpening, string createdBy)
        {

            var jobOpeningModel = _mapper.Map<JobOpening>(jobOpening);

            jobOpeningModel.CreatedBy = createdBy;
            jobOpeningModel.CreatedTime = DateTime.Now;
            jobOpeningModel.UpdatedBy = createdBy;
            jobOpeningModel.UpdatedTime = DateTime.Now;

            _repository.AddJobOpening(jobOpeningModel);
        }

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


        public void Update(JobOpeningViewModel jobOpening, string updatedBy)
        {
            var jobExisting = _repository.GetJobOpeningById(jobOpening.Id);
            _mapper.Map(jobOpening, jobExisting);
            jobExisting.UpdatedBy = updatedBy;
            jobExisting.UpdatedTime = DateTime.Now;

            _repository.UpdateJobOpening(jobExisting);
        }

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
