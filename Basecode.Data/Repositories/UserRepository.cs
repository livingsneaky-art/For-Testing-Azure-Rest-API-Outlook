using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly BasecodeContext _context;
        public UserRepository(IUnitOfWork unitOfWork, BasecodeContext context) : base(unitOfWork)
        {
            _context = context;
        }

        public IQueryable<User> RetrieveAll()
        {
            return this.GetDbSet<User>();
        }

        public void Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            return _context.User.Find(id);
        }

        public void Update(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.User.Find(id);
            if (data != null)
            {
                _context.User.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}
