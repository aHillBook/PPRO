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
    public class ZaznamyController : Controller
    {
        private readonly DB _context;

        public ZaznamyController(DB context)
        {
            ViewData["adminVolba"] = 5;
            _context = context;
        }

        // GET: Zaznamy
        public async Task<IActionResult> Index()
        {
            ViewData["adminVolba"] = 5;
            var dB = _context.seznamZaznamu.Include(z => z.termin).Include(z => z.uzivatel);
            return View(await dB.ToListAsync());
        }

        // GET: Zaznamy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 5;
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
        public IActionResult Create()
        {
            ViewData["adminVolba"] = 5;
            ViewData["idTerminu"] = new SelectList(_context.seznamTerminu, "idTerminu", "idTerminu");
            ViewData["idUzivatele"] = new SelectList(_context.seznamUzivatelu, "idUzivatele", "idUzivatele");
            return View();
        }

        // POST: Zaznamy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idZaznamu,idTerminu,idUzivatele,datumPrihlaseni")] Zaznam zaznam)
        {
            ViewData["adminVolba"] = 5;
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
            ViewData["adminVolba"] = 5;
            if (id == null)
            {
                return NotFound();
            }

            var zaznam = await _context.seznamZaznamu.FindAsync(id);
            if (zaznam == null)
            {
                return NotFound();
            }
            ViewData["idTerminu"] = new SelectList(_context.seznamTerminu, "idTerminu", "idTerminu", zaznam.idTerminu);
            ViewData["idUzivatele"] = new SelectList(_context.seznamUzivatelu, "idUzivatele", "idUzivatele", zaznam.idUzivatele);
            return View(zaznam);
        }

        // POST: Zaznamy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idZaznamu,idTerminu,idUzivatele,datumPrihlaseni")] Zaznam zaznam)
        {
            ViewData["adminVolba"] = 5;
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
            ViewData["adminVolba"] = 5;
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
            ViewData["adminVolba"] = 5;
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
