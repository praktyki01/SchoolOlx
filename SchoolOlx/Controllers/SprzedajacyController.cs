using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolOlx.Data;
using SchoolOlx.Models;

namespace SchoolOlx.Controllers
{
    public class SprzedajacyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SprzedajacyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sprzedajacy
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sprzedajacy.Include(s => s.Klasa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sprzedajacy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sprzedajacy == null)
            {
                return NotFound();
            }

            var sprzedajacy = await _context.Sprzedajacy
                .Include(s => s.Klasa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sprzedajacy == null)
            {
                return NotFound();
            }

            return View(sprzedajacy);
        }

        // GET: Sprzedajacy/Create
        public IActionResult Create()
        {
            ViewData["KlasaId"] = new SelectList(_context.Set<Klasa>(), "Id", "Id");
            return View();
        }

        // POST: Sprzedajacy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,KlasaId,DaneKontaktowe")] Sprzedajacy sprzedajacy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprzedajacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlasaId"] = new SelectList(_context.Set<Klasa>(), "Id", "Id", sprzedajacy.KlasaId);
            return View(sprzedajacy);
        }

        // GET: Sprzedajacy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sprzedajacy == null)
            {
                return NotFound();
            }

            var sprzedajacy = await _context.Sprzedajacy.FindAsync(id);
            if (sprzedajacy == null)
            {
                return NotFound();
            }
            ViewData["KlasaId"] = new SelectList(_context.Set<Klasa>(), "Id", "Id", sprzedajacy.KlasaId);
            return View(sprzedajacy);
        }

        // POST: Sprzedajacy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,KlasaId,DaneKontaktowe")] Sprzedajacy sprzedajacy)
        {
            if (id != sprzedajacy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprzedajacy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprzedajacyExists(sprzedajacy.Id))
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
            ViewData["KlasaId"] = new SelectList(_context.Set<Klasa>(), "Id", "Id", sprzedajacy.KlasaId);
            return View(sprzedajacy);
        }

        // GET: Sprzedajacy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sprzedajacy == null)
            {
                return NotFound();
            }

            var sprzedajacy = await _context.Sprzedajacy
                .Include(s => s.Klasa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sprzedajacy == null)
            {
                return NotFound();
            }

            return View(sprzedajacy);
        }

        // POST: Sprzedajacy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sprzedajacy == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sprzedajacy'  is null.");
            }
            var sprzedajacy = await _context.Sprzedajacy.FindAsync(id);
            if (sprzedajacy != null)
            {
                _context.Sprzedajacy.Remove(sprzedajacy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprzedajacyExists(int id)
        {
          return (_context.Sprzedajacy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
