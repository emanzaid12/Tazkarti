using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tazkarty.Data;
using Tazkarty.Models;
using Tazkarty.ViewModel;

namespace Tazkarty.Controllers
{
    public class TicketController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BookTicket(int matchId)
        {
            var match = await _db.Matches
                .FirstOrDefaultAsync(m => m.MatchId == matchId);

            if (match == null)
                return NotFound();

            var viewModel = new BookTicketViewModel
            {
                Match = match,
                Location = "Specify location here",
                Price = 50.00m,
            };

            return View(viewModel);
        }




        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmBooking(int matchId, string location, decimal price)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var ticket = new Ticket
            {
                MatchId = matchId,
                UserId = userId,
                BookingTime = DateTime.Now,
                Location = location,
                Price = price
            };

            _db.Tickets.Add(ticket);
            await _db.SaveChangesAsync();

            return RedirectToAction("MyTickets");
        }


        [Authorize]
        public IActionResult MyTickets()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var tickets = _db.Tickets
                .Include(t => t.Match)
                .Where(t => t.UserId == userId)
                .ToList();

            return View(tickets);
        }
    }
}
