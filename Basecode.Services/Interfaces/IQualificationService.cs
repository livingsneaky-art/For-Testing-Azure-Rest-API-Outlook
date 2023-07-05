using Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Interfaces
{
    public interface IQualificationService
    {
        List<Qualification> GetQualifications();
        void Create(Qualification qualification);
        Qualification GetById(int id);

        List<Qualification> GetQualificationsByJobOpeningId(int jobOpeningId);
        void Update(Qualification qualification);
        void Delete(Qualification qualification);
    }
}
