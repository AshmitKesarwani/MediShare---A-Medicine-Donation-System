using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediShare.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; } = "";
        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Mobile")]
        public string Mobile { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Re-Enter Password")]
        public string ConfirmPassword { get; set; }
       public string Role { get; set; } = "User";
    }
}
