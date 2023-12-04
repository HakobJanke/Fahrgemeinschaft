using System.ComponentModel.DataAnnotations;

namespace Fahrgemeinschaft.Models
{
    public class FahrtenViewModel
    {
        [Display(Name = "Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name ="Abfahrtszeit")]
        [Required(ErrorMessage ="Bitte einen Abfahrtszeitpunkt auswählen")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public string? Time { get; set; }

        [Display(Name ="Ortschaften")]
        [Required(ErrorMessage ="Gib die Ortschaften ein, die du passierst")]
        public string? Ortschaften { get; set; }

    }
}
