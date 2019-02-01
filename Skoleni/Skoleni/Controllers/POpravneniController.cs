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
    public class POpravneniController : Controller
    {
        private readonly DB _context;

        public POpravneniController(DB context)
        {
            _context = context;
        }

        // GET: POpravneni
        public async Task<IActionResult> Index()
        {
            ViewData["adminVolba"] = 6;
            var vm = POpravneniServ.getSeznamOpravneniViewModel(_context);

            var dB = _context.seznamOpravneni.Include(u => u.uzivatel).Include(d=>d.role);
            return View(await dB.ToListAsync());
            //return View(vm);
        }

        // GET: POpravneni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 6;
            if (id == null)
            {
                return NotFound();
            }

            var pOpravneni = await _context.seznamOpravneni
                .FirstOrDefaultAsync(m => m.idUzivatele == id);
            if (pOpravneni == null)
            {
                return NotFound();
            }
            else
            {
                pOpravneni.uzivatel = await _context.seznamUzivatelu
                .FirstOrDefaultAsync(m => m.idUzivatele == pOpravneni.idUzivatele);
                pOpravneni.role = await _context.seznamRoli
                    .FirstOrDefaultAsync(m => m.idRole == pOpravneni.idRole);
                pOpravneni.uzivatel.jmeno = pOpravneni.uzivatel.jmeno + " " + pOpravneni.uzivatel.prijmeni;
                pOpravneni.idRole = pOpravneni.role.idRole;
                pOpravneni.idUzivatele = pOpravneni.uzivatel.idUzivatele;
            }
            return View(pOpravneni);
        }

        // GET: POpravneni/Create
        public IActionResult Create()
        {
            ViewData["adminVolba"] = 6;
            POpravneniViewModel vm = POpravneniServ.getOpravneniBlankViewModel(_context);
            return View(vm);
        }

        // POST: POpravneni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUzivatele,idRole")] POpravneni pOpravneni)
        {
            ViewData["adminVolba"] = 6;
            if (ModelState.IsValid)
            {
                _context.Add(pOpravneni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idUzivatele"] = new SelectList(_context.seznamUzivatelu, "idUzivatele", "idUzivatele", pOpravneni.idUzivatele);
            ViewData["idRole"] = new SelectList(_context.seznamUzivatelu, "idRole", "idRole", pOpravneni.idRole);
            return View(pOpravneni);
        }

        // GET: POpravneni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["adminVolba"] = 6;
            if (id == null)
            {
                return NotFound();
            }

            var pOpravneni = await _context.seznamOpravneni
                .FirstOrDefaultAsync(m => m.idUzivatele == id);

            if (pOpravneni == null)
            {
                return NotFound();
            }
            POpravneniViewModel vm = new POpravneniViewModel();

            vm = POpravneniServ.getOpravneniFillViewModel(_context, pOpravneni);
            return View(vm);
        }

        // POST: POpravneni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUzivatele,idRole")] POpravneni o)
        {
            ViewData["adminVolba"] = 6;
            if (id != o.idUzivatele)
            {
                return NotFound();
            }
            POpravneni test = await _context.seznamOpravneni.FirstOrDefaultAsync(m => m.idUzivatele == o.idUzivatele);
            var pOpravneni = await _context.seznamOpravneni.FindAsync(o.idUzivatele, test.idRole);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.seznamOpravneni.Remove(pOpravneni);
                    await _context.SaveChangesAsync();
                    _context.seznamOpravneni.Add(o);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!POpravneniExists(pOpravneni.idUzivatele))
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
            ViewData["idUzivatele"] = new SelectList(_context.seznamUzivatelu, "idUzivatele", "idUzivatele", pOpravneni.idUzivatele);
            ViewData["idRole"] = new SelectList(_context.seznamUzivatelu, "idRole", "idRole", pOpravneni.idRole);
            return View(pOpravneni);
        }
        
        // GET: POpravneni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["adminVolba"] = 6;
            if (id == null)
            {
                return NotFound();
            }

            var pOpravneni = await _context.seznamOpravneni
                .FirstOrDefaultAsync(m => m.idUzivatele == id);
            
            if (pOpravneni == null)
            {
                return NotFound();
            }
            else
            {
                pOpravneni.uzivatel = await _context.seznamUzivatelu
                .FirstOrDefaultAsync(m => m.idUzivatele == pOpravneni.idUzivatele);
                pOpravneni.role = await _context.seznamRoli
                    .FirstOrDefaultAsync(m => m.idRole == pOpravneni.idRole);
                pOpravneni.uzivatel.jmeno = pOpravneni.uzivatel.jmeno + " " + pOpravneni.uzivatel.prijmeni;
                pOpravneni.idRole = pOpravneni.role.idRole;
                pOpravneni.idUzivatele = pOpravneni.uzivatel.idUzivatele;
            }

            return View(pOpravneni);
        }

        // POST: POpravneni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(POpravneni o)
        {
            ViewData["adminVolba"] = 6;

            var pOpravneni = await _context.seznamOpravneni.FindAsync(o.idUzivatele, o.idRole);
            _context.seznamOpravneni.Remove(pOpravneni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool POpravneniExists(int id)
        {
            return _context.seznamOpravneni.Any(e => e.idUzivatele == id);
        }
    }
}
