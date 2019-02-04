using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skoleni.ActionFilters;
using Skoleni.Models;
using Skoleni.Services;
using Skoleni.ViewModels;

namespace Skoleni.Controllers
{
    public class ProfilController : Controller
    {
        private readonly DB _context;

        public ProfilController(DB context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["mainVolba"] = 3;
            int idUzivatele = (int)HttpContext.Session.GetInt32("roleId");
            if (idUzivatele == 0)
            {
                return NotFound();
            }

            var uzivatel = await _context.seznamUzivatelu.FindAsync(idUzivatele);
            if (uzivatel == null)
            {
                return NotFound();
            }
 
            return View(UzivateleServ.getUzivatelFillViewModel(_context, uzivatel));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("idUzivatele,jmeno,prijmeni,stredisko,email,idJazyka,nt,heslo")] Uzivatel uzivatel)
        {
            ViewData["mainVolba"] = 3;

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

                
                ViewBag.uspesne = "Úspěšně uloženo";
            }

            return View(UzivateleServ.getUzivatelFillViewModel(_context, uzivatel));
        }
        private bool UzivatelExists(int id)
        {
            return _context.seznamUzivatelu.Any(e => e.idUzivatele == id);
        }
    }
}