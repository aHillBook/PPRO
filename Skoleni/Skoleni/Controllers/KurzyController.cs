using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skoleni.Services;
using Skoleni.ViewModels;

namespace Skoleni.Controllers
{
    public class KurzyController : Controller
    {
        public IActionResult Prehled(int? idMesice, int? idRoku)
        {
            ViewData["mainVolba"] = 1;

            DenViewModel vm;
            if (idMesice == null || idRoku == null)
                vm = DnyServ.getMesicViewModel();
            else
                vm = DnyServ.getMesicViewModel((int)idMesice, (int)idRoku);

            return View(vm);
        }
    }
}