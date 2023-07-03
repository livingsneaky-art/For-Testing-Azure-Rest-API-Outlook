using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basecode.Services.Services
{
    public class JobOpeningService : IJobOpeningService
    {
        private readonly IJobOpeningRepository _repository;

        public JobOpeningService(IJobOpeningRepository repository)
        {
            _repository = repository;
        }

        public List<JobOpening> GetJobs()
        {
            return _repository.GetAll().ToList();
        }

        public void Create(JobOpening jobOpening, string createdBy)
        {
            jobOpening.CreatedBy = createdBy;
            jobOpening.CreatedTime = DateTime.Now;
            jobOpening.UpdatedBy = createdBy;
            jobOpening.UpdatedTime = DateTime.Now;

            _repository.AddJobOpening(jobOpening);
        }
    }
}
