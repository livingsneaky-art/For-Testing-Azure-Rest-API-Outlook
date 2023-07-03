using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> RetrieveAll();
        void Add(User user);
        User GetById(int id);
        void Update(User user);
        void Delete(int id);
    }
}
