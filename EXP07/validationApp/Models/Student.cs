using System.ComponentModel.DataAnnotations;

namespace ValidationApp.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(18, 30, ErrorMessage = "Age must be between 18 and 30")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
