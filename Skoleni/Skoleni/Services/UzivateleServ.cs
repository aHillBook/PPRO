using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skoleni.Models;
using Skoleni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Skoleni.Services
{
    public static class UzivateleServ
    {
        public static async Task<UzivatelViewModel> getSeznamUzivateluViewModel(DB context, int? stranka)
        {
            UzivatelViewModel vm = new UzivatelViewModel();


            vm.seznamUzivatelu = await context.seznamUzivatelu.Include(u => u.jazyk).ToListAsync();

            var poradi = stranka ?? 1;

            vm.strankovanySeznam = vm.seznamUzivatelu.ToPagedList(poradi, 20);

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
