using Microsoft.AspNetCore.Mvc.Rendering;
using Skoleni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.ViewModels
{
    public class ZaznamViewModel
    {
        public Zaznam zaznam { get; set; }

        public SelectList seznamTerminu { get; set; }
        public SelectList seznamUzivatelu { get; set; }
    }
}
