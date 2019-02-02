using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skoleni.Models;
using Skoleni.Services;
using Skoleni.ViewModels;

namespace Skoleni.Controllers
{
    public class KurzyController : Controller
    {
        private readonly DB _context;

        public KurzyController(DB context)
        {
            _context = context;
        }
        public async Task<IActionResult> Prehled(int? idMesice, int? idRoku)
        {
            ViewData["mainVolba"] = 1;

            var seznam = _context.seznamTerminu.Include(t => t.jazyk).Include(t => t.mistnost).Include(t => t.skoleni);


            DenViewModel vm;
            if (idMesice == null || idRoku == null)
                vm = DnyServ.getMesicViewModel(seznam);
            else
                vm = DnyServ.getMesicViewModel((int)idMesice, (int)idRoku, seznam);

            return View( vm);
        }

        public ActionResult Den(DateTime? datum)
        {
            ViewData["mainVolba"] = 1;

            DenViewModel vm;

            if (datum == null)
            {
                return Redirect("Prehled");
            }
            else
            {
                vm = DnyServ.getDenViewModel((DateTime)datum);


            }

            return View(vm);
        }
    }
}