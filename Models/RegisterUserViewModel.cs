using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public record class RegisterUserViewModel
    {
        [Required]
        [MinLength(1)]
        public string? FirstName { get; set; }
        
        [Required]
        [MinLength(1)]
        public string? SecondName { get; set; }
        
        [Required]
        [MinLength(1)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$")]
        public string? PhoneNumber { get; set; }
    }
}
