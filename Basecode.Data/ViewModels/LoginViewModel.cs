using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        public string Password { get; set; } 
    }
}
