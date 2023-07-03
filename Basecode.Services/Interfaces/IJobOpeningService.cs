using Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Interfaces
{
    public interface IJobOpeningService
    {
        List<JobOpening> GetJobs();
        void Create(JobOpening jobOpening, string createdBy);

        JobOpening GetById(int id);

        void Update(JobOpening jobOpening, string updatedBy);
    }
}
