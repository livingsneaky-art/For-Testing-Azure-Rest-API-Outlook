using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.Repositories;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicantService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ApplicantService(IApplicantRepository repository)
        {
            _repository = repository;
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
    }
}
