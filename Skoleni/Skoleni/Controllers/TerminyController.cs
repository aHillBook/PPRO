using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skoleni.ActionFilters;
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
        [ServiceFilter(typeof(SpravceFiltr))]
        public async Task<IActionResult> Index()
        {
            ViewData["adminVolba"] = 4;
            var dB = _context.seznamTerminu.Include(t => t.jazyk).Include(t => t.mistnost).Include(t => t.skoleni);
            return View(await dB.ToListAsync());
        }

        // GET: Terminy/Details/5
        [ServiceFilter(typeof(SpravceFiltr))]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 4;
            if (id == null)
            {
                return NotFound();
            }

            var termin = await _context.seznamTerminu
                .Include(t => t.jazyk)
                .Include(t => t.mistnost)
                .Include(t => t.skoleni)
                .FirstOrDefaultAsync(m => m.idTerminu == id);
            if (termin == null)
            {
                return NotFound();
            }

            return View(termin);
        }

        // GET: Terminy/Create
        [ServiceFilter(typeof(SpravceFiltr))]
        public IActionResult Create()
        {
            ViewData["adminVolba"] = 4;
            TerminViewModel vm = TerminyServ.getTerminBlankViewModel(_context);
            return View(vm);
        }

        // POST: Terminy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ServiceFilter(typeof(SpravceFiltr))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTerminu,terminKonani,dobaTrvani,idJazyka,idSkoleni,idMistnosti")] Termin termin)
        {
            ViewData["adminVolba"] = 4;
            if (ModelState.IsValid)
            {
                _context.Add(termin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idJazyka"] = new SelectList(_context.seznamJazyku, "idJazyka", "idJazyka", termin.idJazyka);
            ViewData["idMistnosti"] = new SelectList(_context.seznamMistnosti, "idMistnosti", "idMistnosti", termin.idMistnosti);
            ViewData["idSkoleni"] = new SelectList(_context.seznamSkoleni, "idSkoleni", "idSkoleni", termin.idSkoleni);
            return View(TerminyServ.getTerminBlankViewModel(_context));
        }

        // GET: Terminy/Edit/5
        [ServiceFilter(typeof(SpravceFiltr))]
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
            TerminViewModel vm = TerminyServ.getTerminFillViewModel(_context, termin);
            return View(vm);
        }

        // POST: Terminy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ServiceFilter(typeof(SpravceFiltr))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTerminu,terminKonani,dobaTrvani,idJazyka,idSkoleni,idMistnosti")] Termin termin)
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
            ViewData["idJazyka"] = new SelectList(_context.seznamJazyku, "idJazyka", "idJazyka", termin.idJazyka);
            ViewData["idMistnosti"] = new SelectList(_context.seznamMistnosti, "idMistnosti", "idMistnosti", termin.idMistnosti);
            ViewData["idSkoleni"] = new SelectList(_context.seznamSkoleni, "idSkoleni", "idSkoleni", termin.idSkoleni);
            return View(TerminyServ.getTerminFillViewModel(_context, termin));
        }

        // GET: Terminy/Delete/5
        [ServiceFilter(typeof(SpravceFiltr))]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["adminVolba"] = 4;
            if (id == null)
            {
                return NotFound();
            }

            var termin = await _context.seznamTerminu
                .Include(t => t.jazyk)
                .Include(t => t.mistnost)
                .Include(t => t.skoleni)
                .FirstOrDefaultAsync(m => m.idTerminu == id);
            if (termin == null)
            {
                return NotFound();
            }

            return View(termin);
        }

        // POST: Terminy/Delete/5
        [ServiceFilter(typeof(SpravceFiltr))]
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
