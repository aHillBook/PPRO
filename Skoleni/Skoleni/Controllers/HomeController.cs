﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Skoleni.ViewModels;
using Microsoft.AspNetCore.Http;
using Skoleni.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Skoleni.Controllers
{
    public class HomeController : Controller
    {
        private readonly DB _context;

        public HomeController(DB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["mainVolba"] = 0;
            return View();
        }

        public IActionResult About()
        {
            ViewData["mainVolba"] = 0;
            return View();
        }


        public IActionResult Privacy()
        {
            ViewData["mainVolba"] = 0;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewData["mainVolba"] = 0;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            ViewData["mainVolba"] = 0;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (string nt, string heslo)
        {
            ViewData["mainVolba"] = 0;
            if (nt != null && heslo != null)
            {
                var uzivatel = await _context.seznamUzivatelu.FirstOrDefaultAsync(m => m.heslo.Equals(heslo) && m.nt.Equals(nt));

                if (uzivatel != null)
                {
                    HttpContext.Session.SetString("userName", uzivatel.prijmeni + " " + uzivatel.jmeno);
                    HttpContext.Session.SetInt32("userId", uzivatel.idUzivatele);
                    var opravneni = await _context.seznamOpravneni.Include(o => o.role).FirstOrDefaultAsync(p => p.idUzivatele == uzivatel.idUzivatele);
                    if (opravneni != null)
                    {
                        HttpContext.Session.SetString("userRole", opravneni.role.nazev);
                        HttpContext.Session.SetInt32("roleId", opravneni.role.idRole);
                    }
                    else
                    {
                        HttpContext.Session.SetString("userRole", "");
                        HttpContext.Session.SetInt32("roleId", 3);
                    }
                    return Redirect("Index");
                }
            }
            ViewBag.chyba = "Nesprávné údaje";
            return View();
        }

        public IActionResult Logout()
        {
            ViewData["mainVolba"] = 0;
            HttpContext.Session.Clear();

            return Redirect("Index");
        }
    }
}
