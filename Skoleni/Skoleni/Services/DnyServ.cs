using Skoleni.Models;
using Skoleni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Services
{
    public class DnyServ
    {
        private static List<String> mesice = new List<string>() { "Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" };
        public static DenViewModel getDenViewModel()
        {
            DenViewModel vm = new DenViewModel();

            vm.seznam = new List<Den>();

            for (int i = 1; i < 32; i++)
            {
                Den d = new Den();
                d.datum = new System.DateTime(2018, 12, 20);
                d.zaznamy = new List<Zaznam>();

                vm.seznam.Add(d);
            }

            return vm;
        }

        public static DenViewModel getDenViewModel(DateTime datum)
        {
            DenViewModel vm = new DenViewModel();

            Den d = new Den();
            d.datum = datum;
            vm.d = d;

            //vm.seznam = new List<Den>();

            //for (int i = 1; i < 32; i++)
            //{
            //    Den d = new Den();
            //    d.datum = new System.DateTime(2018, 12, 20);
            //    d.zaznamy = new List<Polozka>();

            //    d.zaznamy.Add(new Polozka() { poradi = 1, jmeno = "Kobliha Karel", osCislo = 111111, nadrizeny = "Dvořák Petr", stredisko = 515251 });
            //    d.zaznamy.Add(new Polozka() { poradi = 4, jmeno = "Foltinová Blanka", osCislo = 32, nadrizeny = "Dvořák Petr", stredisko = 515251 });
            //    d.zaznamy.Add(new Polozka() { poradi = 5, jmeno = "Fišer Patrik", osCislo = 4590, nadrizeny = "Černáš Petr", stredisko = 515103 });

            //    vm.seznam.Add(d);
            //}
            return vm;
        }


        public static DenViewModel getMesicViewModel()
        {
            DenViewModel vm = new DenViewModel();

            vm.seznam = new List<Den>();


            generuj(vm, DateTime.Now.Month, DateTime.Now.Year, vm.terminy);


            return vm;
        }

        public static DenViewModel getMesicViewModel(IQueryable<Termin> seznamTerminu)
        {
            DenViewModel vm = new DenViewModel();

            vm.seznam = new List<Den>();
            vm.terminy = seznamTerminu.ToList();


            generuj(vm, DateTime.Now.Month, DateTime.Now.Year, vm.terminy);


            return vm;
        }

        public static DenViewModel getMesicViewModel(int idMesice, int idRoku, IQueryable<Termin> seznamTerminu)
        {
            DenViewModel vm = new DenViewModel();

            vm.seznam = new List<Den>();
            vm.terminy = seznamTerminu.ToList();


            generuj(vm, idMesice, idRoku, vm.terminy);

            return vm;
        }

        private static void generuj(DenViewModel vm, int idMesice, int idRoku)
        {
            var prvniDen = new DateTime(idRoku, idMesice, 1);
            vm.aktualniRok = idRoku;

            int denTydne = (int)prvniDen.DayOfWeek;


            // doplneni prazdnych bloku
            if (denTydne == 0)
            {
                for (int i = 1; i < 7; i++)
                    vm.seznam.Add(new Den() { nic = true });
            }
            else
            {
                for (int i = 1; i < denTydne; i++)
                    vm.seznam.Add(new Den() { nic = true });
            }

            // ostatni dny
            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, idMesice); i++)
            {
                var den = new Den();
                denTydne = (int)prvniDen.DayOfWeek;
                if (denTydne == 0 || denTydne == 6 || prvniDen < DateTime.Now)
                    den.prazdny = true;


                den.datum = prvniDen;
                den.denTydne = (int)prvniDen.DayOfWeek;
                vm.seznam.Add(den);
                prvniDen = prvniDen.AddDays(1);
            }


            vm.aktualniMesic = mesice[idMesice - 1].ToString();
            // *** predchozi mesic
            if (idMesice == 1)
            {
                vm.predchoziRok = vm.aktualniRok - 1;
                vm.predchoziMesic = mesice[11] + " (" + (vm.predchoziRok) + ")";
                vm.idPredchoziMesic = 12;
            }
            else
            {
                vm.predchoziRok = vm.aktualniRok;
                vm.predchoziMesic = mesice[idMesice - 2].ToString();
                vm.idPredchoziMesic = idMesice - 1;

            }

            // *** nasledujici mesic
            if (idMesice == 12)
            {
                vm.nasledujiciRok = vm.aktualniRok + 1;
                vm.nasledujiciMesic = mesice[0] + " (" + (vm.nasledujiciRok) + ")";
                vm.idNasledujiciMesic = 1;
            }
            else
            {
                vm.nasledujiciRok = vm.aktualniRok;
                vm.nasledujiciMesic = mesice[idMesice].ToString();
                vm.idNasledujiciMesic = idMesice + 1;

            }

        }

        private static void generuj(DenViewModel vm, int idMesice, int idRoku, List<Termin> terminy)
        {
            var prvniDen = new DateTime(idRoku, idMesice, 1);
            vm.aktualniRok = idRoku;

            int denTydne = (int)prvniDen.DayOfWeek;

            

            // doplneni prazdnych bloku
            if (denTydne == 0)
            {
                for (int i = 1; i < 7; i++)
                    vm.seznam.Add(new Den() { nic = true });
            }
            else
            {
                for (int i = 1; i < denTydne; i++)
                    vm.seznam.Add(new Den() { nic = true });
            }

            // ostatni dny
            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, idMesice); i++)
            {
                var den = new Den();
                den.datum = prvniDen;

                denTydne = (int)prvniDen.DayOfWeek;
                if (denTydne == 0 || denTydne == 6 || prvniDen < DateTime.Now)
                {
                    den.prazdny = true;
                }
                else
                {
                    var t = terminy.Where(x => x.terminKonani.Equals(den.datum)).ToList();
                    if (t.Count > 0)
                    {
                        den.prazdny = false;
                        den.terminy = t;
                        foreach (var x in t)
                        {
                            den.pocetVolnychMist += x.mistnost.kapacita;
                            //den.pocetVolnychMist -= prihlasky.Where(a => a.termin.id == x.id).ToList().Count;
                        }
                    }
                    else
                    {
                        den.prazdny = true;
                        den.pocetVolnychMist = 0;
                    }
                }


                den.denTydne = (int)prvniDen.DayOfWeek;
                vm.seznam.Add(den);
                prvniDen = prvniDen.AddDays(1);
            }


            vm.aktualniMesic = mesice[idMesice - 1].ToString();
            // *** predchozi mesic
            if (idMesice == 1)
            {
                vm.predchoziRok = vm.aktualniRok - 1;
                vm.predchoziMesic = mesice[11] + " (" + (vm.predchoziRok) + ")";
                vm.idPredchoziMesic = 12;
            }
            else
            {
                vm.predchoziRok = vm.aktualniRok;
                vm.predchoziMesic = mesice[idMesice - 2].ToString();
                vm.idPredchoziMesic = idMesice - 1;

            }

            // *** nasledujici mesic
            if (idMesice == 12)
            {
                vm.nasledujiciRok = vm.aktualniRok + 1;
                vm.nasledujiciMesic = mesice[0] + " (" + (vm.nasledujiciRok) + ")";
                vm.idNasledujiciMesic = 1;
            }
            else
            {
                vm.nasledujiciRok = vm.aktualniRok;
                vm.nasledujiciMesic = mesice[idMesice].ToString();
                vm.idNasledujiciMesic = idMesice + 1;

            }

        }

    }
}
