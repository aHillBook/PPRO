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
    public class ZaznamyController : Controller
    {
        int IDskoleni;
        private readonly DB _context;

        public ZaznamyController(DB context)
        {
            
            _context = context;
        }

        // GET: Zaznamy
        public async Task<IActionResult> Index(int idSkoleni)
        {
            if (idSkoleni == 0) idSkoleni = 1;

            IDskoleni = idSkoleni; 
            ViewData["adminVolba"] = 7;
            var vm = await ZaznamyServ.getSeznamZaznamuSkoleniViewModel(_context, idSkoleni);

            return View(vm);
        }
        // GET: Zaznamy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 7;
            if (id == null)
            {
                return NotFound();
            }

            var zaznam = await _context.seznamZaznamu
                .Include(z => z.termin)
                .Include(z => z.uzivatel)
                .FirstOrDefaultAsync(m => m.idZaznamu == id);
            if (zaznam == null)
            {
                return NotFound();
            }

            return View(zaznam);
        }

        // GET: Zaznamy/Create
        public IActionResult Create([Bind("idSkoleni")]int idSkoleni)
        {
            ViewData["adminVolba"] = 7;
            ZaznamViewModel vm = ZaznamyServ.getZaznamBlankViewModel(_context, IDskoleni);
            return View(vm);
        }

        // POST: Zaznamy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idZaznamu,idTerminu,idUzivatele,datumPrihlaseni")] Zaznam zaznam)
        {
            ViewData["adminVolba"] = 7;
            if (ModelState.IsValid)
            {
                _context.Add(zaznam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idTerminu"] = new SelectList(_context.seznamTerminu, "idTerminu", "idTerminu", zaznam.idTerminu);
            ViewData["idUzivatele"] = new SelectList(_context.seznamUzivatelu, "idUzivatele", "idUzivatele", zaznam.idUzivatele);
            return View(zaznam);
        }

        // GET: Zaznamy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["adminVolba"] = 7;
            if (id == null)
            {
                return NotFound();
            }

            var zaznam = await _context.seznamZaznamu.FindAsync(id);
            if (zaznam == null)
            {
                return NotFound();
            }
            ZaznamViewModel vm = ZaznamyServ.getZaznamFillViewModel(_context, zaznam);
            return View(vm);
        }

        // POST: Zaznamy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idZaznamu,idTerminu,idUzivatele,datumPrihlaseni")] Zaznam zaznam)
        {
            ViewData["adminVolba"] = 7;
            if (id != zaznam.idZaznamu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zaznam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZaznamExists(zaznam.idZaznamu))
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
            ViewData["idTerminu"] = new SelectList(_context.seznamTerminu, "idTerminu", "idTerminu", zaznam.idTerminu);
            ViewData["idUzivatele"] = new SelectList(_context.seznamUzivatelu, "idUzivatele", "idUzivatele", zaznam.idUzivatele);
            return View(zaznam);
        }

        // GET: Zaznamy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["adminVolba"] = 7;
            if (id == null)
            {
                return NotFound();
            }

            var zaznam = await _context.seznamZaznamu
                .Include(z => z.termin)
                .Include(z => z.uzivatel)
                .FirstOrDefaultAsync(m => m.idZaznamu == id);
            if (zaznam == null)
            {
                return NotFound();
            }

            return View(zaznam);
        }

        // POST: Zaznamy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["adminVolba"] = 7;
            var zaznam = await _context.seznamZaznamu.FindAsync(id);
            _context.seznamZaznamu.Remove(zaznam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZaznamExists(int id)
        {
            return _context.seznamZaznamu.Any(e => e.idZaznamu == id);
        }
    }
}
