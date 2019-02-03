using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skoleni.ActionFilters;
using Skoleni.Models;

namespace Skoleni.Controllers
{
    public class SkoleniController : Controller
    {
        private readonly DB _context;

        public SkoleniController(DB context)
        {
            _context = context;
        }

        // GET: Skoleni
        [ServiceFilter(typeof(AdminFiltr))]
        public async Task<IActionResult> Index()
        {
            ViewData["adminVolba"] = 3;
            return View(await _context.seznamSkoleni.ToListAsync());
        }

        // GET: Skoleni/Details/5
        [ServiceFilter(typeof(AdminFiltr))]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 3;
            if (id == null)
            {
                return NotFound();
            }

            var skoleni = await _context.seznamSkoleni
                .FirstOrDefaultAsync(m => m.idSkoleni == id);
            if (skoleni == null)
            {
                return NotFound();
            }

            return View(skoleni);
        }

        // GET: Skoleni/Create
        public IActionResult Create()
        {
            ViewData["adminVolba"] = 3;
            return View();
        }

        // POST: Skoleni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ServiceFilter(typeof(AdminFiltr))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSkoleni,nazev,popis,skolitel")] Models.PSkoleni skoleni)
        {
            ViewData["adminVolba"] = 3;
            if (ModelState.IsValid)
            {
                _context.Add(skoleni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skoleni);
        }

        // GET: Skoleni/Edit/5
        [ServiceFilter(typeof(AdminFiltr))]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["adminVolba"] = 3;
            if (id == null)
            {
                return NotFound();
            }

            var skoleni = await _context.seznamSkoleni.FindAsync(id);
            if (skoleni == null)
            {
                return NotFound();
            }
            return View(skoleni);
        }

        // POST: Skoleni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ServiceFilter(typeof(AdminFiltr))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSkoleni,nazev,popis,skolitel")] Models.PSkoleni skoleni)
        {
            ViewData["adminVolba"] = 3;
            if (id != skoleni.idSkoleni)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skoleni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkoleniExists(skoleni.idSkoleni))
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
            return View(skoleni);
        }

        // GET: Skoleni/Delete/5
        [ServiceFilter(typeof(AdminFiltr))]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["adminVolba"] = 3;
            if (id == null)
            {
                return NotFound();
            }

            var skoleni = await _context.seznamSkoleni
                .FirstOrDefaultAsync(m => m.idSkoleni == id);
            if (skoleni == null)
            {
                return NotFound();
            }

            return View(skoleni);
        }

        // POST: Skoleni/Delete/5
        [ServiceFilter(typeof(AdminFiltr))]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["adminVolba"] = 3;
            var skoleni = await _context.seznamSkoleni.FindAsync(id);
            _context.seznamSkoleni.Remove(skoleni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkoleniExists(int id)
        {
            return _context.seznamSkoleni.Any(e => e.idSkoleni == id);
        }
    }
}
