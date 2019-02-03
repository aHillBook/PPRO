using Microsoft.AspNetCore.Mvc.Rendering;
using Skoleni.Models;
using Skoleni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Services
{
    public class POpravneniServ
    {
        public static POpravneniViewModel getSeznamOpravneniViewModel(DB context)
        {
            POpravneniViewModel vm = new POpravneniViewModel();

            return vm;
        }

        public static POpravneniViewModel getOpravneniBlankViewModel(DB context)
        {
            POpravneniViewModel vm = new POpravneniViewModel();

            vm.opravneni = new POpravneni();

            var kolekceUzivatelu = context.seznamUzivatelu.OrderBy(a => a.prijmeni).Select(b => new { Id = b.idUzivatele, Value = b.prijmeni + " " + b.jmeno });
            vm.seznamUzivatelu = new SelectList(kolekceUzivatelu, "Id", "Value");

            var kolekceRoli = context.seznamRoli.OrderBy(a => a.nazev).Select(b => new { Id = b.idRole, Value = b.nazev });
            vm.seznamRoli = new SelectList(kolekceRoli, "Id", "Value");

            return vm;
        }
        public static POpravneniViewModel getOpravneniViewModel(DB context)
        {
            POpravneniViewModel vm = new POpravneniViewModel();
            vm.opravneni = new POpravneni();

            return vm;
        }
        public static POpravneniViewModel getOpravneniFillViewModel(DB context, POpravneni opravneni)
        {
            POpravneniViewModel vm = new POpravneniViewModel();

            vm.opravneni = opravneni;
            vm.idRole = opravneni.idRole;
            vm.idUzivatele = opravneni.idUzivatele;
            vm.opravneni.uzivatel =  context.seznamUzivatelu
                .FirstOrDefault(m => m.idUzivatele == opravneni.idUzivatele);

            var kolekceRoli = context.seznamRoli.OrderBy(a => a.nazev).Select(b => new { Id = b.idRole, Value = b.nazev });
            vm.seznamRoli = new SelectList(kolekceRoli, "Id", "Value");


            return vm;
        }
    }
}
