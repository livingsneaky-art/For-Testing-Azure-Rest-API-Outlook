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
        /// Retrieves all users as a list of UserViewModel objects.
        /// Calls the corresponding method in the repository to fetch the users and then transforms
        /// them into a view model format before returning the list.
        /// </summary>
        /// <returns>A collection of UserViewModel representing all users available.</returns>
        List<UserViewModel> RetrieveAll();

        /// <summary>
        /// Adds a new user to the system by calling the corresponding method in the repository.
        /// </summary>
        /// <param name="user">User object representing the user to be added.</param>
        void Add(User user);

        /// <summary>
        /// Retrieves a specific user based on the provided ID
        /// by calling the corresponding method in the repository.
        /// </summary>
        /// <param name="id">Represents the ID of the user to fetch.</param>
        /// <returns>A User object corresponding to the matching ID.</returns>
        User GetById(int id);

        /// <summary>
        /// Updates an existing user by calling the corresponding method in the repository.
        /// </summary>
        /// <param name="user">Represents the user with updated information.</param>
        void Update(User user);

        /// <summary>
        /// Deletes a user from the system based on the provided ID
        /// by calling the corresponding method in the repository.
        /// </summary>
        /// <param name="id">Represents the ID of the user to be deleted.</param>
        void Delete(int id);
    }
}
