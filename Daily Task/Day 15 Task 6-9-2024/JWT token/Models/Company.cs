using System.ComponentModel.DataAnnotations;

namespace ApiEx.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string ?CompanyName { get; set; }

        public ICollection<Employee> ?Employees { get; set; }
    }
}
