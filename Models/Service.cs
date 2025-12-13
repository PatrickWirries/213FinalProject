using System.ComponentModel.DataAnnotations;

namespace _213FinalProject.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Range(1, 1440)]
        public int DurationMinutes { get; set; }

        [Range(0, 1000000)]
        public decimal BasePrice { get; set; }

        [StringLength(100)]
        public string? Category { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
