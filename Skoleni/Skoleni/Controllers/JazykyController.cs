using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skoleni.Models;

namespace Skoleni.Controllers
{
    public class JazykyController : Controller
    {
        private readonly DB _context;

        public JazykyController(DB context)
        {
            _context = context;
        }

        // GET: Jazyky
        public async Task<IActionResult> Index()
        {
            ViewData["adminVolba"] = 1;
            return View(await _context.seznamJazyku.ToListAsync());
        }

        // GET: Jazyky/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["adminVolba"] = 1;
            if (id == null)
            {
                return NotFound();
            }

            var jazyk = await _context.seznamJazyku
                .FirstOrDefaultAsync(m => m.idJazyka == id);
            if (jazyk == null)
            {
                return NotFound();
            }

            return View(jazyk);
        }

        // GET: Jazyky/Create
        public IActionResult Create()
        {
            ViewData["adminVolba"] = 1;
            return View();
        }

        // POST: Jazyky/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idJazyka,nazev")] Jazyk jazyk)
        {
            ViewData["adminVolba"] = 1;
            if (ModelState.IsValid)
            {
                _context.Add(jazyk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jazyk);
        }

        // GET: Jazyky/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["adminVolba"] = 1;
            if (id == null)
            {
                return NotFound();
            }

            var jazyk = await _context.seznamJazyku.FindAsync(id);
            if (jazyk == null)
            {
                return NotFound();
            }
            return View(jazyk);
        }

        // POST: Jazyky/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idJazyka,nazev")] Jazyk jazyk)
        {
            ViewData["adminVolba"] = 1;
            if (id != jazyk.idJazyka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jazyk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JazykExists(jazyk.idJazyka))
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
            return View(jazyk);
        }

        // GET: Jazyky/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["adminVolba"] = 1;
            if (id == null)
            {
                return NotFound();
            }

            var jazyk = await _context.seznamJazyku
                .FirstOrDefaultAsync(m => m.idJazyka == id);
            if (jazyk == null)
            {
                return NotFound();
            }

            return View(jazyk);
        }

        // POST: Jazyky/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["adminVolba"] = 1;
            var jazyk = await _context.seznamJazyku.FindAsync(id);
            _context.seznamJazyku.Remove(jazyk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JazykExists(int id)
        {
            return _context.seznamJazyku.Any(e => e.idJazyka == id);
        }
    }
}
