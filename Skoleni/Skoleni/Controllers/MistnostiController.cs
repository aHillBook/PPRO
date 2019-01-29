using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skoleni.Models;

namespace Skoleni.Controllers
{
    public class MistnostiController : Controller
    {
        private readonly DB _context;

        public MistnostiController(DB context)
        {
            _context = context;
        }

        // GET: Mistnosti
        public async Task<IActionResult> Index()
        {
            ViewData["adminVolba"] = 2;
            return View(await _context.seznamMistnosti.ToListAsync());
        }

        // GET: Mistnosti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 2;
            if (id == null)
            {
                return NotFound();
            }

            var mistnost = await _context.seznamMistnosti
                .FirstOrDefaultAsync(m => m.idMistnosti == id);
            if (mistnost == null)
            {
                return NotFound();
            }

            return View(mistnost);
        }

        // GET: Mistnosti/Create
        public IActionResult Create()
        {
            ViewData["adminVolba"] = 2;
            return View();
        }

        // POST: Mistnosti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idMistnosti,nazev,kapacita")] Mistnost mistnost)
        {
            ViewData["adminVolba"] = 2;
            if (ModelState.IsValid)
            {
                _context.Add(mistnost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mistnost);
        }

        // GET: Mistnosti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["adminVolba"] = 2;
            if (id == null)
            {
                return NotFound();
            }

            var mistnost = await _context.seznamMistnosti.FindAsync(id);
            if (mistnost == null)
            {
                return NotFound();
            }
            return View(mistnost);
        }

        // POST: Mistnosti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idMistnosti,nazev,kapacita")] Mistnost mistnost)
        {
            ViewData["adminVolba"] = 2;
            if (id != mistnost.idMistnosti)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mistnost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MistnostExists(mistnost.idMistnosti))
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
            return View(mistnost);
        }

        // GET: Mistnosti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["adminVolba"] = 2;
            if (id == null)
            {
                return NotFound();
            }

            var mistnost = await _context.seznamMistnosti
                .FirstOrDefaultAsync(m => m.idMistnosti == id);
            if (mistnost == null)
            {
                return NotFound();
            }

            return View(mistnost);
        }

        // POST: Mistnosti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["adminVolba"] = 2;
            var mistnost = await _context.seznamMistnosti.FindAsync(id);
            _context.seznamMistnosti.Remove(mistnost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MistnostExists(int id)
        {
            return _context.seznamMistnosti.Any(e => e.idMistnosti == id);
        }
    }
}
