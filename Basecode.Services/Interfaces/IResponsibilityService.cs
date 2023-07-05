using Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Interfaces
{
    public interface IResponsibilityService
    {
        List<Responsibility> GetResponsibilities();
        void Create(Responsibility responsibility);
        Responsibility GetById(int id);

        List<Responsibility> GetResponsibilitiesByJobOpeningId(int jobOpeningId);
        void Update(Responsibility responsibility);
        void Delete(Responsibility responsibility);
    }
}
