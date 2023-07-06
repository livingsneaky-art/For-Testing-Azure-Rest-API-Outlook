using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.ViewModels
{
    /// <summary>
    /// View model for application tracker.
    /// </summary>
    public class ApplicationViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the applcation.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the job opening ID.
        /// </summary>
        public int JobOpeningId { get; set; }

        /// <summary>
        /// Gets or sets the applicant ID.
        /// </summary>
        public int ApplicantId { get; set; }

        /// <summary>
        /// Gets or sets the application status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the update time of the application.
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
