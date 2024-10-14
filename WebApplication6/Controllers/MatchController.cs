using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tazkarty.Data;
using Tazkarty.Models;
using System.Linq;
using System.Threading.Tasks;
using Tazkarty.ViewModel;

namespace Tazkarty.Controllers
{
    public class MatchController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create() => View();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CreateMatchViewModel request)
        {
            var match = new Models.Match()
            {
                TeamA=request.TeamA,
                TeamB=request.TeamB,
                MatchDate=request.MatchDate,
                
            };
            _db.Matches.Add(match);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Index()
        {
            var matches = _db.Matches.ToList();
            return View(matches);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var match = await _db.Matches
                .Include(m => m.Tickets)
                .FirstOrDefaultAsync(m => m.MatchId == id);

            if (match == null)
                return NotFound();

            return View(match);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var match = await _db.Matches.FindAsync(id);

            if (match == null)
                return NotFound();

            return View(match);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var match =  _db.Matches.FirstOrDefault(x => x.MatchId == id);

            if (match == null)
            {
                return NotFound();

            }
            _db.Matches.Remove(match);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
