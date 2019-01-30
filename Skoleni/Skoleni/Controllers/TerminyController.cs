using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skoleni.Models;
using Skoleni.Services;
using Skoleni.ViewModels;

namespace Skoleni.Controllers
{
    public class TerminyController : Controller
    {
        private readonly DB _context;

        public TerminyController(DB context)
        {
            _context = context;
        }

        // GET: Terminy
        public async Task<IActionResult> Index()
        {
            ViewData["adminVolba"] = 4;
            return View(await _context.seznamTerminu.ToListAsync());
        }

        // GET: Terminy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 4;
            if (id == null)
            {
                return NotFound();
            }

            var termin = await _context.seznamTerminu
                .FirstOrDefaultAsync(m => m.idTerminu == id);
            if (termin == null)
            {
                return NotFound();
            }

            return View(termin);
        }

        // GET: Terminy/Create
        public IActionResult Create()
        {
            ViewData["adminVolba"] = 4;
            TerminViewModel vm = new TerminViewModel();

            vm = TerminyServ.getTerminBlankViewModel(_context);

            return View(vm);
        }

        // POST: Terminy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTerminu,terminKonani,dobaTrvani")] Termin termin)
        {
            ViewData["adminVolba"] = 4;
            if (ModelState.IsValid)
            {
                _context.Add(termin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(termin);
        }

        // GET: Terminy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["adminVolba"] = 4;
            if (id == null)
            {
                return NotFound();
            }

            var termin = await _context.seznamTerminu.FindAsync(id);
            if (termin == null)
            {
                return NotFound();
            }
            return View(termin);
        }

        // POST: Terminy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTerminu,terminKonani,dobaTrvani")] Termin termin)
        {
            ViewData["adminVolba"] = 4;
            if (id != termin.idTerminu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminExists(termin.idTerminu))
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
            return View(termin);
        }

        // GET: Terminy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["adminVolba"] = 4;
            if (id == null)
            {
                return NotFound();
            }

            var termin = await _context.seznamTerminu
                .FirstOrDefaultAsync(m => m.idTerminu == id);
            if (termin == null)
            {
                return NotFound();
            }

            return View(termin);
        }

        // POST: Terminy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["adminVolba"] = 4;
            var termin = await _context.seznamTerminu.FindAsync(id);
            _context.seznamTerminu.Remove(termin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerminExists(int id)
        {
            return _context.seznamTerminu.Any(e => e.idTerminu == id);
        }
    }
}
