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
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepository _repository;

        public QualificationService(IQualificationRepository repository)
        {
            _repository = repository;
        }
        public List<Qualification> GetQualifications()
        {
            var data = _repository.GetAll().Select(m => new Qualification
            {
                Id = m.Id,
                JobOpeningId = m.JobOpeningId,
                Description = m.Description
            }).ToList();

            return data;
        }

        public void Create(Qualification qualification)
        {
            _repository.AddQualification(qualification);
        }

        public Qualification GetById(int id)
        {
            var data = _repository.GetAll().Where(m => m.Id == id).Select(m => new Qualification
            {
                Id = m.Id,
                JobOpeningId = m.JobOpeningId,
                Description = m.Description
            }).FirstOrDefault();

            return data;
        }


        public void Update(Qualification qualification)
        {
            var qualificationExisting = _repository.GetQualificationById(qualification.Id);
            qualificationExisting.Description = qualification.Description;

            _repository.UpdateQualification(qualificationExisting);
        }

        public void Delete(Qualification qualification)
        { 
            _repository.DeleteQualification(qualification);
        }
    }
}
