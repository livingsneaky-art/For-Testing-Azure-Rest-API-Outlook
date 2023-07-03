using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.ViewModels
{
    public class JobOpeningViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EmploymentType { get; set; }
        public string WorkSetup { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
    }
}
