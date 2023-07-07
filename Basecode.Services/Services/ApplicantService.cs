using AutoMapper;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.Repositories;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Services.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicantService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ApplicantService(IApplicantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the applicants.
        /// </summary>
        /// <returns></returns>
        public List<Applicant> GetApplicants()
        {
            return _repository.GetAll().ToList();
        }
        
        public Applicant GetApplicantById(int id)
        {
            return _repository.GetById(id);
        }

        public (LogContent, int) Create(ApplicantViewModel applicant)
        {
            LogContent logContent = new LogContent();

            logContent = CheckApplicant(applicant);
            if (logContent.Result == false)
            {
                var applicantModel = _mapper.Map<Applicant>(applicant);

                int createdApplicantId = _repository.CreateApplicant(applicantModel);

                return (logContent, createdApplicantId); // Return both LogContent and the created applicant ID
            }

            return (logContent, -1); // Return an invalid ID if the creation fails
        }
    }
}
