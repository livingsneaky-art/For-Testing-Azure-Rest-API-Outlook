using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Basecode.Services.Services.ErrorHandling;

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
        /// Creates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        LogContent Create(User user);

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
        LogContent Update(User user);

        /// <summary>
        /// Deletes a user from the system based on the provided ID.
        /// </summary>
        /// <param name="id">Represents the ID of the user to be deleted.</param>
        void Delete(int id);

        Match CheckEmailDomain(string email);
    }
}
