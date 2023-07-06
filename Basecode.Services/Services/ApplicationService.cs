using AutoMapper;
using Basecode.Data.Interfaces;
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
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ApplicationService(IApplicationRepository repository, IMapper mapper, IJobOpeningService jobOpeningService)
        {
            _repository = repository;
            _jobOpeningService = jobOpeningService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves an application by its ID.
        /// </summary>
        /// <param name="id">The ID of the application to retrieve.</param>
        /// <returns>
        /// The application with the specified ID, or null if not found.
        /// </returns>
        public ApplicationViewModel GetById(Guid id)
        {
            var application = _repository.GetById(id);
            var job = _jobOpeningService.GetById(application.JobOpeningId);
            var data = new ApplicationViewModel
            {
                Id = application.Id,
                ApplicantId = application.ApplicantId,
                JobOpeningTitle = job.Title,
                Status = application.Status,
                UpdateTime = application.UpdateTime
            };

            return data;
        }
    }
}