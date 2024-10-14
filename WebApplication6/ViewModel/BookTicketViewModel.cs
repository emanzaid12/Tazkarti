using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Tazkarty.Models;

namespace Tazkarty.ViewModel
{
    public class BookTicketViewModel
    {
        [Required]
        [Display(Name = "Match")]
        public int MatchId { get; set; }
        public Match Match { get; set; }


        public string Location { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<SelectListItem> Matches{ get; set; }
    }
}