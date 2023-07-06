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
        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>A list of UserViewModel objects representing all users available.</returns>
        List<UserViewModel> RetrieveAll();

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="user">User object representing the user to be added.</param>
        void Add(User user);

        /// <summary>
        /// Retrieves a specific user based on the provided ID.
        /// </summary>
        /// <param name="id">Represents the ID of the user to fetch.</param>
        /// <returns>A User object corresponding to the matching ID.</returns>
        User GetById(int id);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">Represents the user with updated information.</param>
        void Update(User user);

        /// <summary>
        /// Deletes a user from the system based on the provided ID.
        /// </summary>
        /// <param name="id">Represents the ID of the user to be deleted.</param>
        void Delete(int id);
    }
}
