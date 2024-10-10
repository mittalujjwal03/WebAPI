using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        public string? DepartmentName { get; set; }

        public ICollection<Employee>? Employees { get; set; }

        public int EmployeeCount => Employees?.Count ?? 0;
    }
}
