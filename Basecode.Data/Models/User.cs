using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Represents the full name of a user.
        /// </summary>
        [Required]
        [DisplayName("Full Name")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string Fullname { get; set; }

        /// <summary>
        /// Represents the username associated with a user.
        /// </summary>
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Special characters are not allowed.")]
        [StringLength(50)]
        public string Username { get; set; }

        /// <summary>
        /// Represents the email address of a user.
        /// </summary>
        [Required]
        [DisplayName("Email Address")]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Represents the password associated with a user.
        /// </summary>
        [Required]
        //[StringLength(50, MinimumLength = 8)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [MaxLength(50, ErrorMessage = "Password must be a maximum of 50 characters.")]
        public string Password { get; set; }

        /// <summary>
        /// Represents the role or position of a user in the system.
        /// Examples: Human Resources, Deployment Team
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }
}
