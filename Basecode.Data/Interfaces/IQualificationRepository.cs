using Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.Interfaces
{
    public interface IQualificationRepository
    {
        IQueryable<Qualification> GetAll();
        void AddQualification(Qualification qualification);
        Qualification GetQualificationById(int id);
        void UpdateQualification(Qualification qualification);
        void DeleteQualification(Qualification qualification);
    }
}
