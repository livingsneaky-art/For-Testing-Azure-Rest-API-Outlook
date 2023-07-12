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
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicantService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ApplicantService(IApplicantRepository repository, IApplicationRepository applicationRepository, IMapper mapper)
        {
            _repository = repository;
            _applicationRepository = applicationRepository;
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

        /// <summary>
        /// Retrieves an applicant by its ID.
        /// </summary>
        /// <param name="id">The ID of the applicant.</param>
        /// <returns>The Applicant object.</returns>
        public Applicant GetApplicantById(int id)
        {
            return _repository.GetById(id);
        }

        /// <summary>
        /// Creates a new applicant.
        /// </summary>
        /// <param name="applicant">The ApplicantViewModel object containing the applicant data.</param>
        /// <returns>A tuple containing a LogContent object and the ID of the created applicant.</returns>
        public LogContent Create(ApplicantViewModel applicant, List<CharacterReferenceViewModel> references)
        {
            LogContent logContent = new LogContent();

            logContent = CheckApplicant(applicant);
            if (logContent.Result == false)
            {

                applicant.CharacterReferences = references;
                
                var applicantModel = _mapper.Map<Applicant>(applicant);

                int createdApplicantId = _repository.CreateApplicant(applicantModel);

                var application = new Application
                {
                    JobOpeningId = applicant.JobOpeningId, 
                    ApplicantId = createdApplicantId, 
                    Status = "Pending", 
                    ApplicationDate = DateTime.Now, 
                    UpdateTime = DateTime.Now 
                };

                _applicationRepository.CreateApplication(application);

            }

            return logContent;
        }

    }
}
