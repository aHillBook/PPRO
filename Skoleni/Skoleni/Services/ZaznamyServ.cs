using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skoleni.Models;
using Skoleni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Services
{
    public class ZaznamyServ
    {
        public async static Task<ZaznamViewModel> getSeznamZaznamuSkoleniViewModel(DB context, int idSkoleni)
        {
            ZaznamViewModel vm = new ZaznamViewModel();
            vm.idSkoleni = idSkoleni;
            vm.zaznamy = await context.seznamZaznamu.Where(d=>d.termin.idSkoleni == idSkoleni).Include(z => z.termin).Include(z => z.uzivatel).ToListAsync();
            var kolekceSkoleni = context.seznamSkoleni.OrderBy(a => a.nazev).Select(b => new { Id = b.idSkoleni, Value = b.nazev });
            vm.seznamSkoleni = new SelectList(kolekceSkoleni, "Id", "Value");

            return vm;
        }
        public async static Task<ZaznamViewModel> getZaznamBlankViewModel(DB context, int idSkoleni)
        {
            ZaznamViewModel vm = new ZaznamViewModel();

            vm.zaznam = new Zaznam();
            
            var kolekceTerminu = await context.seznamTerminu.Where(d=>d.idSkoleni == idSkoleni).OrderBy(a => a.terminKonani).Select(b => new { Id = b.idTerminu, Value = b.skoleni.nazev + " - " + b.mistnost.nazev + " - " + b.terminKonani}).ToListAsync();
            vm.seznamTerminu = new SelectList(kolekceTerminu, "Id", "Value");

            var kolekceUzivatelu = await context.seznamUzivatelu.OrderBy(a => a.prijmeni).Select(b => new { Id = b.idUzivatele, Value = b.prijmeni + " " + b.jmeno }).ToListAsync();
            vm.seznamUzivatelu = new SelectList(kolekceUzivatelu, "Id", "Value");

            return vm;
        }

        public static ZaznamViewModel getZaznamFillViewModel(DB context, Zaznam zaznam)
        {
            ZaznamViewModel vm = new ZaznamViewModel();

            vm.zaznam = zaznam;

            var kolekceTerminu = context.seznamTerminu.OrderBy(a => a.terminKonani).Select(b => new { Id = b.idTerminu, Value = b.skoleni.nazev + " - " + b.mistnost.nazev + " - " + b.terminKonani });
            vm.seznamTerminu = new SelectList(kolekceTerminu, "Id", "Value");

            var kolekceUzivatelu = context.seznamUzivatelu.OrderBy(a => a.prijmeni).Select(b => new { Id = b.idUzivatele, Value = b.prijmeni + " " + b.jmeno });
            vm.seznamUzivatelu = new SelectList(kolekceUzivatelu, "Id", "Value");


            return vm;
        }
    }
}
