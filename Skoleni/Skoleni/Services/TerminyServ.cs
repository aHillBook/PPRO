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
            vm.termin.terminKonani = DateTime.Now;

            var kolekceSkoleni = context.seznamSkoleni.OrderBy(a => a.nazev).Select(b => new { Id = b.idSkoleni, Value = b.nazev });
            vm.seznamSkoleni = new SelectList(kolekceSkoleni, "Id", "Value");

            var kolekceMistnosti = context.seznamMistnosti.OrderBy(a => a.nazev).Select(b => new { Id = b.idMistnosti, Value = b.nazev });
            vm.seznamMistnosti = new SelectList(kolekceMistnosti, "Id", "Value");

            var kolekceJazyku = context.seznamJazyku.OrderBy(a => a.nazev).Select(b => new { Id = b.idJazyka, Value = b.nazev });
            vm.seznamJazyku = new SelectList(kolekceJazyku, "Id", "Value");


            return vm;
        }

        public static TerminViewModel getTerminFillViewModel(DB context, Termin termin)
        {
            TerminViewModel vm = new TerminViewModel();

            vm.termin = termin;

            var kolekceSkoleni = context.seznamSkoleni.OrderBy(a => a.nazev).Select(b => new { Id = b.idSkoleni, Value = b.nazev });
            vm.seznamSkoleni = new SelectList(kolekceSkoleni, "Id", "Value");

            var kolekceMistnosti = context.seznamMistnosti.OrderBy(a => a.nazev).Select(b => new { Id = b.idMistnosti, Value = b.nazev });
            vm.seznamMistnosti = new SelectList(kolekceMistnosti, "Id", "Value");

            var kolekceJazyku = context.seznamJazyku.OrderBy(a => a.nazev).Select(b => new { Id = b.idJazyka, Value = b.nazev });
            vm.seznamJazyku = new SelectList(kolekceJazyku, "Id", "Value");


            return vm;
        }
    }
}
