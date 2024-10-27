using System.ComponentModel.DataAnnotations;

namespace RazorPage.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeName { get; set; } = string.Empty;

        public int DepartmentNo { get; set; }
    }
}
