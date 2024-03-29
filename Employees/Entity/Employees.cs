﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Employees.Entity
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [MaxLength(4)]
        public int PassportSeries { get; set; }
        [MaxLength(6)]
        public int PassportNumber { get; set; }
        public int OrganizationId { get; set;}
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
    }
}
