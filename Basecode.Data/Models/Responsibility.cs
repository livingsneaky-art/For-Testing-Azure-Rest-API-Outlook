using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Data.Models
{
    public class Responsibility
    {
        public int Id { get; set; }

        public int JobOpeningId { get; set; }

        public string Description { get; set; }
    }
}
