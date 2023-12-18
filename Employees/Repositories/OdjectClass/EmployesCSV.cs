using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Repositories.OdjectClass
{
    public class EmployesCSV
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public string OrganizationName { get; set; }
        public string INN { get; set; }
        public string LegalAddress { get; set; }
        public string ActualAddress { get; set; }
    }
}
