using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CricketMatch.Data;
using CricketMatch.Models;
using Microsoft.AspNetCore.Authorization;

namespace CricketMatch.Controllers
{
    public class RankingsController : Controller
    {
        private readonly CricketMatchContext _context;

        public RankingsController(CricketMatchContext context)
        {
            _context = context;
        }

        // GET: Rankings
        public async Task<IActionResult> Index()
        {
            var cricketMatchContext = _context.Ranking.Include(r => r.Event).Include(r => r.Player);
            return View(await cricketMatchContext.ToListAsync());
        }

        // GET: Rankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking
                .Include(r => r.Event)
                .Include(r => r.Player)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }
        [Authorize]
        // GET: Rankings/Create
        public IActionResult Create()
        {
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "Eventname");
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerFname");
            return View();
        }

        // POST: Rankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PlayerID,EventID")] Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ranking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventID", ranking.EventID);
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", ranking.PlayerID);
            return View(ranking);
        }
        [Authorize]
        // GET: Rankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "Eventname", ranking.EventID);
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerFname", ranking.PlayerID);
            return View(ranking);
        }

        // POST: Rankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PlayerID,EventID")] Ranking ranking)
        {
            if (id != ranking.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ranking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankingExists(ranking.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventID", ranking.EventID);
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", ranking.PlayerID);
            return View(ranking);
        }
        [Authorize]
        // GET: Rankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking
                .Include(r => r.Event)
                .Include(r => r.Player)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ranking = await _context.Ranking.FindAsync(id);
            _context.Ranking.Remove(ranking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankingExists(int id)
        {
            return _context.Ranking.Any(e => e.ID == id);
        }
    }
}
