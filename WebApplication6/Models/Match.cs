using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tazkarty.Models
{
    public class Match
    {
        public int MatchId { get; set; }

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

        public ICollection<Ticket> Tickets { get; set; }
    }
}
