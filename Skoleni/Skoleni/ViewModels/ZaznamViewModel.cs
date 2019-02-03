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
        public List<Zaznam> zaznamy { get; set; }

        public SelectList seznamTerminu { get; set; }
        public SelectList seznamUzivatelu { get; set; }
        public SelectList seznamSkoleni { get; set; }

        public int idSkoleni { get; set; }
        public string nazevSkoleni { get; set; }
    }
}
