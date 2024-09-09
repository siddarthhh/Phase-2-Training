using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEx.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string? EmployeeName { get; set; }
        public int ?EmployeeAge { get; set; }
        public int ?CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? company { get; set; }
    }
}
