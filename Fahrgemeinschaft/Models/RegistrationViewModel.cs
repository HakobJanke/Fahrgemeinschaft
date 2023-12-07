using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fahrgemeinschaft.Models;

public class RegistrationViewModel
{
    
        [Display(Name = "Vorname")]
        [Required(ErrorMessage = "Gib bitte deinen Vornamen ein.")]
        public string? FirstName { get; set; }

        [Display(Name = "Nachname")]
        [Required(ErrorMessage = "Gib bitte deinen Nachnamen ein.")]
        public string? LastName { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Gib bitte deine E-Mail ein.")]
        public string? MailAddress { get; set; }

        [Display(Name = "Geburtsdatum")]
        [Required(ErrorMessage = "Gib bitte dein Geburtsdatum ein.")]
        [DataType(DataType.Date)]
        public string? BirthDate { get; set; }

        [Display(Name = "Passwort")]
        [Required(ErrorMessage = "Gib bitte dein Passwort ein.")]
        public string? Password { get; set; }

        public string? Fahrer { get; set; }

        public string? Mitfahrer { get; set; }
}
