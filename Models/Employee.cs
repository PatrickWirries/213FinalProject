using System.ComponentModel.DataAnnotations;

namespace _213FinalProject.Models
{
    public class Employee : User
    {
        [Key]
        public int EmployeeID { get; set; }

        [StringLength(1000)]
        public string? Bio { get; set; }

        [Required]
        public DateOnly HireDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
