using System.ComponentModel.DataAnnotations;

namespace _213FinalProject.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int ServiceID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public DateOnly ScheduledDate { get; set; }

        [Required]
        public TimeOnly ScheduledTime { get; set; }

        [Range(1, 1440)]
        public int Duration { get; set; }

        [Range(0, 1000000)]
        public decimal Price { get; set; }
    }
}
