using System.ComponentModel.DataAnnotations;

namespace Fahrgemeinschaft.Models
{
    public class FahrtenViewModel
    {
        [Display(Name = "Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name ="departure time")]
        [Required(ErrorMessage ="plase select a time for departure")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public string? Time { get; set; }

        [Display(Name ="Cities")]
        [Required(ErrorMessage ="plase type in the cities you pass")]
        public string? Ortschaften { get; set; }

        [Display(Name ="Which students are allowed to drive with you")]
        public string? OnlyFifthGrade { get; set; }
    }
}
