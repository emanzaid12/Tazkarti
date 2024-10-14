namespace Tazkarty.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 

        public DateTime BookingTime { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
