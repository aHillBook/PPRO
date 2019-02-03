using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skoleni.ActionFilters;
using Skoleni.Models;
using Skoleni.Services;
using Skoleni.ViewModels;

namespace Skoleni.Controllers
{
    public class KurzyController : Controller
    {
        private readonly DB _context;

        public KurzyController(DB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Prehled(int? idMesice, int? idRoku)
        {
            ViewData["mainVolba"] = 1;

            var seznam = _context.seznamTerminu.Include(t => t.jazyk).Include(t => t.mistnost).Include(t => t.skoleni);


            DenViewModel vm;
            if (idMesice == null || idRoku == null)
                vm = DnyServ.getMesicViewModel(seznam);
            else
                vm = DnyServ.getMesicViewModel((int)idMesice, (int)idRoku, seznam);

            return View( vm);
        }

        public IActionResult Den(DateTime? datum)
        {
            ViewData["mainVolba"] = 1;

            DenViewModel vm;

            if (datum == null)
            {
                return Redirect("Prehled");
            }
            else
            {
                var seznam = _context.seznamTerminu.Include(t => t.jazyk).Include(t => t.mistnost).Include(t => t.skoleni);
                vm = DnyServ.getDenViewModel((DateTime)datum, _context);


            }

            return View(vm);
        }

        [ServiceFilter(typeof(PrihlasenFiltr))]
        public IActionResult Prihlasit(int? id)
        {
            ViewData["mainVolba"] = 1;
            if (id != null)
            {
                var termin = _context.seznamTerminu.Include(t => t.jazyk).Include(t => t.mistnost).Include(t => t.skoleni).Where(t => t.idTerminu == id).FirstOrDefault();

                var zaznam = _context.seznamZaznamu.Include(z => z.termin).Include(z => z.uzivatel).Where(x => x.uzivatel.idUzivatele == HttpContext.Session.GetInt32("userId") && x.termin.idTerminu == id).FirstOrDefault();
                
                if(zaznam != null)
                {
                    ViewData["jizPrihlasen"] = "x";
                }
                return View(termin);
            }
            else
            {
                return RedirectToAction("Prehled");
            }
        }

        [ServiceFilter(typeof(PrihlasenFiltr))]
        [HttpPost]
        public async Task<IActionResult> Prihlasit(IFormCollection data)
        {
            ViewData["mainVolba"] = 1;

            int cislo;

            if(int.TryParse(data["idTerminu"], out cislo))
             {
                int idTerminu = cislo;

                Zaznam z = new Zaznam();
                z.idTerminu = idTerminu;
                z.idUzivatele = (int)HttpContext.Session.GetInt32("userId");
                z.datumPrihlaseni = DateTime.Now;

                _context.Add(z);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Prehled");
        }
    }
}