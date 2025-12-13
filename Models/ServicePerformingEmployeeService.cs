using System.ComponentModel.DataAnnotations;

namespace _213FinalProject.Models
{
    public class ServicePerformingEmployeeService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int ServiceID { get; set; }

        // Navigation properties (optional)
        public Service? Service { get; set; }
        public ServicePerforming? Employee { get; set; }
    }
}
