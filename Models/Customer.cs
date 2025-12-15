using System.ComponentModel.DataAnnotations;

namespace _213FinalProject.Models
{
    public class Customer : User
    {


        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [StringLength(2000)]
        public string? Notes { get; set; }

        [Required]
        [MinLength(64), MaxLength(128)]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
