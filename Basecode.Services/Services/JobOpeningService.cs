using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Services
{
    public class JobOpeningService : IJobOpeningService
    {
        private readonly IJobOpeningRepository _repository;

        public JobOpeningService(IJobOpeningRepository repository)
        {
            _repository = repository;
        }

        public List<JobOpening> GetApplicants()
        {
            return _repository.GetAll().ToList();
        }
    }
}
