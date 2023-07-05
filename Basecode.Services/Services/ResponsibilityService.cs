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
    public class ResponsibilityService: IResponsibilityService
    {
        private readonly IResponsibilityRepository _repository;

        public ResponsibilityService(IResponsibilityRepository repository)
        {
            _repository = repository;
        }
        public List<Responsibility> GetResponsibilities()
        {
            var data = _repository.GetAll().Select(m => new Responsibility
            {
                Id = m.Id,
                JobOpeningId = m.JobOpeningId,
                Description = m.Description
            }).ToList();

            return data;
        }

        public void Create(Responsibility Responsibility)
        {
            _repository.AddResponsibility(Responsibility);
        }

        public Responsibility GetById(int id)
        {
            var data = _repository.GetAll().Where(m => m.Id == id).Select(m => new Responsibility
            {
                Id = m.Id,
                JobOpeningId = m.JobOpeningId,
                Description = m.Description
            }).FirstOrDefault();

            return data;
        }

        public List<Responsibility> GetResponsibilitiesByJobOpeningId(int jobOpeningId)
        {
            var data = _repository.GetAll().Where(m => m.JobOpeningId == jobOpeningId).Select(m => new Responsibility
            {
                Id = m.Id,
                JobOpeningId = m.JobOpeningId,
                Description = m.Description
            }).ToList();

            return data;
        }



        public void Update(Responsibility responsibility)
        {
            var responsibilityExisting = _repository.GetResponsibilityById(responsibility.Id);
            responsibilityExisting.Description = responsibility.Description;

            _repository.UpdateResponsibility(responsibilityExisting);
        }

        public void Delete(Responsibility responsibility)
        {
            _repository.DeleteResponsibility(responsibility);
        }
    }
}
