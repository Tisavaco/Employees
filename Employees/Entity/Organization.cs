using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entity
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(12)]
        public string INN { get; set; }
        public string LegalAddress { get; set;}
        public string ActualAddress { get; set; }
        public List<Employees> Employes { get; set; }

    }
}
