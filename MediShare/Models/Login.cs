using System.ComponentModel.DataAnnotations;

namespace MediShare.Models
{
    public class Login
    {
        
        [Required(ErrorMessage ="Enter Username")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string? Password { get; set; }
     
    }
}
