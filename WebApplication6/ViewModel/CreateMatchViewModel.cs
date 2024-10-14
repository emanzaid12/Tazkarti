using System.ComponentModel.DataAnnotations;

namespace Tazkarty.ViewModel
{
    public class CreateMatchViewModel
    {
        [Required]
        [Display(Name = "Team A")]
        public string TeamA { get; set; }

        [Required]
        [Display(Name = "Team B")]
        public string TeamB { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Match Date")]
        public DateTime MatchDate { get; set; }
    }
}
