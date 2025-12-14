using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

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

        [Required]
        //The below regular expression validates that the URL is in a proper format.
        [RegularExpression("^(?:http(s)?:\\/\\/)?[\\w.-]+(?:\\.[\\w\\.-]+)+[\\w\\-\\._~:/?#[\\]@!\\$&'\\(\\)\\*\\+,;=.]+$")]
        public required String PhotoURL { get; set; }
    }
}
