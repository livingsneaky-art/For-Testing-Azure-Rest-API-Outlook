using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.Repositories;
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

        public List<User> RetrieveAll()
        {
            return _repository.RetrieveAll().ToList();
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
            _repository.Update(user);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
