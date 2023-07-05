using Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.ViewModels
{
    /// <summary>
    /// View model for a job opening.
    /// </summary>
    public class JobOpeningViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the job opening.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the job opening.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the employment type of the job opening.
        /// </summary>
        public string EmploymentType { get; set; }

        /// <summary>
        /// Gets or sets the work setup of the job opening.
        /// </summary>
        public string WorkSetup { get; set; }

        /// <summary>
        /// Gets or sets the location of the job opening.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the category of the job opening.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the qualifications of the job opening.
        /// </summary>
        public List<Qualification> Qualifications{ get; set; }
    }
}
