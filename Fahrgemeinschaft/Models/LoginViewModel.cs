using System.ComponentModel.DataAnnotations;

namespace Fahrgemeinschaft.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please insert a username")]
        public string? Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="please insert a password")]
        public string? Password { get; set; }   
    }
}
