using Microsoft.AspNetCore.Mvc.Rendering;
using Skoleni.Models;
using Skoleni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Services
{
    public static class UzivateleServ
    {
        public static UzivatelViewModel getSeznamUzivateluViewModel(DB context)
        {
            UzivatelViewModel vm = new UzivatelViewModel();

            return vm;
        }

        public static UzivatelViewModel getUzivatelBlankViewModel(DB context)
        {
            UzivatelViewModel vm = new UzivatelViewModel();

            vm.uzivatel = new Uzivatel();

            var y = context.seznamJazyku.Count();

            var kolekceJazyku = context.seznamJazyku.OrderBy(a => a.nazev).Select(b => new { Id = b.idJazyka, Value = b.nazev });
            vm.seznamJazyku = new SelectList(kolekceJazyku, "Id", "Value");


            return vm;
        }
        public static UzivatelViewModel getUzivatelFillViewModel(DB context, Uzivatel uzivatel)
        {
            UzivatelViewModel vm = new UzivatelViewModel();

            vm.uzivatel = uzivatel;

            var y = context.seznamJazyku.Count();

            var kolekceJazyku = context.seznamJazyku.OrderBy(a => a.nazev).Select(b => new { Id = b.idJazyka, Value = b.nazev });
            vm.seznamJazyku = new SelectList(kolekceJazyku, "Id", "Value");


            return vm;
        }
    }
}
