using Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.Interfaces
{
    public interface IJobOpeningRepository
    {
        IQueryable<JobOpening> GetAll();
        void AddJobOpening(JobOpening jobOpening);
    }
}
