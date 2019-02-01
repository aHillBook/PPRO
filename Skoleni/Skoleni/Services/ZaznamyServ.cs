using Microsoft.AspNetCore.Mvc.Rendering;
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
        public static ZaznamViewModel getZaznamBlankViewModel(DB context)
        {
            ZaznamViewModel vm = new ZaznamViewModel();

            vm.zaznam = new Zaznam();

            var kolekceTerminu = context.seznamTerminu.OrderBy(a => a.terminKonani).Select(b => new { Id = b.idTerminu, Value = b.skoleni.nazev + " - " + b.mistnost.nazev + " - " + b.terminKonani});
            vm.seznamTerminu = new SelectList(kolekceTerminu, "Id", "Value");

            var kolekceUzivatelu = context.seznamUzivatelu.OrderBy(a => a.prijmeni).Select(b => new { Id = b.idUzivatele, Value = b.prijmeni + " " + b.jmeno });
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
