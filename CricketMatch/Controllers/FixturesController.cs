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
    public class FixturesController : Controller
    {
        private readonly CricketMatchContext _context;

        public FixturesController(CricketMatchContext context)
        {
            _context = context;
        }

        // GET: Fixtures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fixture.ToListAsync());
        }

        // GET: Fixtures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixture
                .FirstOrDefaultAsync(m => m.Fixture_Id == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }
        [Authorize]
        // GET: Fixtures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fixtures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fixture_Id,vs_Team,Country,Date,Ground_Name")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fixture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fixture);
        }
        [Authorize]
        // GET: Fixtures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixture.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }
            return View(fixture);
        }

        // POST: Fixtures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fixture_Id,vs_Team,Country,Date,Ground_Name")] Fixture fixture)
        {
            if (id != fixture.Fixture_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixtureExists(fixture.Fixture_Id))
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
            return View(fixture);
        }
        [Authorize]
        // GET: Fixtures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixture
                .FirstOrDefaultAsync(m => m.Fixture_Id == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        // POST: Fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fixture = await _context.Fixture.FindAsync(id);
            _context.Fixture.Remove(fixture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FixtureExists(int id)
        {
            return _context.Fixture.Any(e => e.Fixture_Id == id);
        }
    }
}
