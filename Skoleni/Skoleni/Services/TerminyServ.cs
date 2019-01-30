using Microsoft.AspNetCore.Mvc.Rendering;
using Skoleni.Models;
using Skoleni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Services
{
    public static class TerminyServ
    {
        
        public static TerminViewModel getSeznamTerminuViewModel(DB context)
        {
            TerminViewModel vm = new TerminViewModel();

            return vm;
        }

        public static TerminViewModel getTerminBlankViewModel(DB context)
        {
            TerminViewModel vm = new TerminViewModel();

            vm.termin = new Termin();

            var x = context.seznamSkoleni.Count();
            var y = context.seznamJazyku.Count();


            var kolekceSkoleni = context.seznamSkoleni.OrderBy(a => a.nazev).Select(b => new { Id = b.idSkoleni, Value = b.nazev });
            vm.seznamSkoleni = new SelectList(kolekceSkoleni, "Id", "Value");

            var kolekceJazyku = context.seznamJazyku.OrderBy(a => a.nazev).Select(b => new { Id = b.idJazyka, Value = b.nazev });
            vm.seznamJazyku = new SelectList(kolekceJazyku, "Id", "Value");

            vm.jazyky = context.seznamJazyku.ToList();


            return vm;
        }
    }
}
