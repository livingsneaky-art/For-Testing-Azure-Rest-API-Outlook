using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.Models
{
    /// <summary>
    /// Represents a user entity with properties that store information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Represents the unique identifier of a user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the full name of a user.
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Represents the username associated with a user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Represents the email address of a user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Represents the password associated with a user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Represents the role or position of a user in the system.
        /// Examples: Human Resources, Deployment Team
        /// </summary>
        public string Role { get; set; }
    }
}
