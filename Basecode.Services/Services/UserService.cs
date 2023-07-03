using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.Repositories;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<UserViewModel> RetrieveAll()
        {
            var data = _repository.RetrieveAll().Select(s => new UserViewModel
            {
                Id = s.Id,
                Fullname = s.Fullname,
                Username = s.Username,
                Email = s.Email,
                Role = s.Role,
            }).ToList();

            return data;
        }

        public void Add(User user)
        {
            _repository.Add(user);
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(User user)
        {
            var userToBeUpdated = _repository.GetById(user.Id);
            userToBeUpdated.Fullname = user.Fullname;
            userToBeUpdated.Username = user.Username;
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.Password = user.Password;
            userToBeUpdated.Role = user.Role;
            _repository.Update(userToBeUpdated);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Add(User user)
        {
            _repository.Add(user);
        }
    }
}
