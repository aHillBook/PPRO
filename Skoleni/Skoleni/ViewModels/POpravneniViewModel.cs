using Microsoft.AspNetCore.Mvc.Rendering;
using Skoleni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.ViewModels
{
    public class POpravneniViewModel
    {
        public POpravneni opravneni { get; set; }
        public SelectList seznamUzivatelu { get; set; }
        public SelectList seznamRoli { get; set; }
        public int idUzivatele { get; set; }
        public int idRole { get; set; }
    }
}
