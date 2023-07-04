using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.ViewModels
{
    /// <summary>
    /// Encapsulates data specifically intended for the presentation and interaction requirements of a user interface. 
    /// Provides a customized representation of user-related information.
    /// </summary>
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
