using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.Models
{
    [Table("Application")]
    public class Application
    {
        public Guid Id { get; set; }
        public int JobOpeningId { get; set; }

        [ForeignKey("Application")]
        public int ApplicantId { get; set; }
        public string Status { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime UpdateTime { get; set; }

        public Applicant Applicant { get; set; }
    }
}