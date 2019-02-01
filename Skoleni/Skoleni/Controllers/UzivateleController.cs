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
    public class UzivateleController : Controller
    {
        private readonly DB _context;

        public UzivateleController(DB context)
        {
            _context = context;
        }

        // GET: Uzivatele
        public async Task<IActionResult> Index(int? stranka)
        {
            ViewData["adminVolba"] = 5;

            var vm = UzivateleServ.getSeznamUzivateluViewModel(_context, stranka);

            var dB = _context.seznamUzivatelu.Include(u => u.jazyk);
            //return View(await dB.ToListAsync());

            return View(vm);
        }

        // GET: Uzivatele/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 5;
            if (id == null)
            {
                return NotFound();
            }

            var uzivatel = await _context.seznamUzivatelu
                .Include(u => u.jazyk)
                .FirstOrDefaultAsync(m => m.idUzivatele == id);
            if (uzivatel == null)
            {
                return NotFound();
            }

            return View(uzivatel);
        }

        // GET: Uzivatele/Create
        public IActionResult Create()
        {
            ViewData["adminVolba"] = 5;
            UzivatelViewModel vm = new UzivatelViewModel();

            vm = UzivateleServ.getUzivatelBlankViewModel(_context);
            return View(vm);
        }

        // POST: Uzivatele/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUzivatele,jmeno,prijmeni,stredisko,email,idJazyka")] Uzivatel uzivatel)
        {
            ViewData["adminVolba"] = 5;
            if (ModelState.IsValid)
            {
                _context.Add(uzivatel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idJazyka"] = new SelectList(_context.seznamJazyku, "idJazyka", "idJazyka", uzivatel.idJazyka);
            return View(uzivatel);
        }

        // GET: Uzivatele/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["adminVolba"] = 5;
            if (id == null)
            {
                return NotFound();
            }

            var uzivatel = await _context.seznamUzivatelu.FindAsync(id);
            if (uzivatel == null)
            {
                return NotFound();
            }
            UzivatelViewModel vm = new UzivatelViewModel();

            vm = UzivateleServ.getUzivatelFillViewModel(_context, uzivatel);
            return View(vm);
            //ViewData["idJazyka"] = new SelectList(_context.seznamJazyku, "idJazyka", "idJazyka", uzivatel.idJazyka);
            //return View(uzivatel);
        }

        // POST: Uzivatele/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUzivatele,jmeno,prijmeni,stredisko,email,idJazyka")] Uzivatel uzivatel)
        {
            ViewData["adminVolba"] = 5;
            if (id != uzivatel.idUzivatele)
            {
                return NotFound();
            }

            uzivatel.heslo = _context.seznamUzivatelu.Where(d => d.idUzivatele == uzivatel.idUzivatele).Select(d => d.heslo).FirstOrDefault();
            uzivatel.nt = _context.seznamUzivatelu.Where(d => d.idUzivatele == uzivatel.idUzivatele).Select(d => d.nt).FirstOrDefault();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzivatel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzivatelExists(uzivatel.idUzivatele))
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
            ViewData["idJazyka"] = new SelectList(_context.seznamJazyku, "idJazyka", "idJazyka", uzivatel.idJazyka);
            return View(uzivatel);
        }

        // GET: Uzivatele/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["adminVolba"] = 5;
            if (id == null)
            {
                return NotFound();
            }

            var uzivatel = await _context.seznamUzivatelu
                .Include(u => u.jazyk)
                .FirstOrDefaultAsync(m => m.idUzivatele == id);
            if (uzivatel == null)
            {
                return NotFound();
            }

            return View(uzivatel);
        }

        // POST: Uzivatele/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["adminVolba"] = 5;
            var uzivatel = await _context.seznamUzivatelu.FindAsync(id);
            _context.seznamUzivatelu.Remove(uzivatel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzivatelExists(int id)
        {
            return _context.seznamUzivatelu.Any(e => e.idUzivatele == id);
        }
    }
}
