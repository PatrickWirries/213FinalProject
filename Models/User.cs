using System.ComponentModel.DataAnnotations;

namespace _213FinalProject.Models
{
    public abstract class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        [Required]
        [MinLength(5), MaxLength(128)]
        public string PasswordHash { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

    }
}
