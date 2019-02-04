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
            vm.nazevSkoleni = await context.seznamSkoleni.Where(d => d.idSkoleni == idSkoleni).Select(d => d.nazev).FirstOrDefaultAsync();
            vm.zaznamy = await context.seznamZaznamu.Where(d=>d.termin.idSkoleni == idSkoleni).OrderBy(a => a.termin.terminKonani).Include(z => z.termin).Include(z => z.uzivatel).ToListAsync();
            var kolekceSkoleni = context.seznamSkoleni.OrderBy(a => a.nazev).Select(b => new { Id = b.idSkoleni, Value = b.nazev });
            vm.seznamSkoleni = new SelectList(kolekceSkoleni, "Id", "Value");

            return vm;
        }
        public async static Task<ZaznamViewModel> getZaznamBlankViewModel(DB context, int idSkoleni)
        {
            ZaznamViewModel vm = new ZaznamViewModel();

            vm.zaznam = new Zaznam();
            vm.idSkoleni = idSkoleni;
            vm.zaznam.termin = context.seznamTerminu.Where(d => d.idSkoleni == idSkoleni).FirstOrDefault();
            vm.nazevSkoleni = await context.seznamSkoleni.Where(d => d.idSkoleni == idSkoleni).Select(d=>d.nazev).FirstOrDefaultAsync();
            var kolekceTerminu = await context.seznamTerminu.Where(d=>d.idSkoleni == idSkoleni).OrderBy(a => a.terminKonani).Select(b => new { Id = b.idTerminu, Value = b.terminKonani.ToShortDateString() + " - " + b.mistnost.nazev }).ToListAsync();
            vm.seznamTerminu = new SelectList(kolekceTerminu, "Id", "Value");
            //vm.zaznam.terminySkoleni = context.seznamTerminu.Where(d => d.idSkoleni == idSkoleni).ToList();

            var kolekceUzivatelu = await context.seznamUzivatelu.OrderBy(a => a.prijmeni).Select(b => new { Id = b.idUzivatele, Value = b.prijmeni + " " + b.jmeno }).ToListAsync();
            vm.seznamUzivatelu = new SelectList(kolekceUzivatelu, "Id", "Value");

            return vm;
        }

        public static ZaznamViewModel getZaznamFillViewModel(DB context, Zaznam zaznam)
        {
            ZaznamViewModel vm = new ZaznamViewModel();

            vm.zaznam = zaznam;

            var kolekceTerminu = context.seznamTerminu.OrderBy(a => a.terminKonani).Select(b => new { Id = b.idTerminu, Value = b.terminKonani.ToShortDateString() + " - " + b.mistnost.nazev });
            vm.seznamTerminu = new SelectList(kolekceTerminu, "Id", "Value");

            var kolekceUzivatelu = context.seznamUzivatelu.OrderBy(a => a.prijmeni).Select(b => new { Id = b.idUzivatele, Value = b.prijmeni + " " + b.jmeno });
            vm.seznamUzivatelu = new SelectList(kolekceUzivatelu, "Id", "Value");


            return vm;
        }
    }
}
