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
        public static POpravneniViewModel getSeznamUzivateluViewModel(DB context)
        {
            POpravneniViewModel vm = new POpravneniViewModel();

            return vm;
        }

        public static POpravneniViewModel getOpravneniBlankViewModel(DB context)
        {
            POpravneniViewModel vm = new POpravneniViewModel();

            vm.opravneni = new POpravneni();
            vm.opravneni.uzivatel = new Uzivatel();
            vm.opravneni.role = new PRole();
            vm.opravneni.idUzivatele = 1;
            var y = context.seznamRoli.Count();

            var kolekceUzivatelu = context.seznamUzivatelu.OrderBy(a => a.prijmeni).Select(b => new { Id = b.idUzivatele, Value = b.prijmeni + " " + b.jmeno });
            vm.seznamUzivatelu = new SelectList(kolekceUzivatelu, "Id", "Value");

            var kolekceRoli = context.seznamRoli.OrderBy(a => a.nazev).Select(b => new { Id = b.idRole, Value = b.nazev });
            vm.seznamRoli = new SelectList(kolekceRoli, "Id", "Value");

            return vm;
        }
        //public static POpravneniViewModel getUzivatelFillViewModel(DB context, Uzivatel uzivatel)
        //{
        //    POpravneniViewModel vm = new POpravneniViewModel();

        //    vm.uzivatel = uzivatel;

        //    var y = context.seznamJazyku.Count();

        //    var kolekceJazyku = context.seznamJazyku.OrderBy(a => a.nazev).Select(b => new { Id = b.idJazyka, Value = b.nazev });
        //    vm.seznamJazyku = new SelectList(kolekceJazyku, "Id", "Value");


        //    return vm;
        //}
    }
}
