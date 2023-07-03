using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Interfaces
{
    public interface IJobOpeningService
    {
        List<JobOpeningViewModel> GetJobs();
        void Create(JobOpening jobOpening, string createdBy);

        JobOpeningViewModel GetById(int id);

        void Update(JobOpeningViewModel jobOpening, string updatedBy);

        void Delete(JobOpeningViewModel jobOpening);
    }
}
