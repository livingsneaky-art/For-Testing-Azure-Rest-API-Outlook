using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.ViewModels
{
    public class ApplicationViewModel
    {
        public Guid Id { get; set; }
        public int JobOpeningId { get; set; }
        public int ApplicantId { get; set; }
        public string Status { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
