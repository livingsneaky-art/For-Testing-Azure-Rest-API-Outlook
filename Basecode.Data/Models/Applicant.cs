﻿using Basecode.Data.ViewModels;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Basecode.Data.Models
{
    [Table("Applicant")]
    public class Applicant
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string? Middlename { get; set; }
        public string Lastname { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Zip { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public byte[] CV { get; set; }

        public List<CharacterReference> CharacterReferences { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}
