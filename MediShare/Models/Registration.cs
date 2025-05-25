using System.ComponentModel.DataAnnotations;

namespace MediShare.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Range(18, 34, ErrorMessage = "You are not eligibile only 18-34 can apply")]
        public string? Age { get; set; }
        [Required(ErrorMessage = "PLease enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid mail id")]
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Country { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression("[a-zA-Z0-9]{3,9}", ErrorMessage = ("Password should be between 3-9 digit"))]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Password not matched")]
        public string? ConfirmPassword { get; set; }
    }
}
