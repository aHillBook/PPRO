using Microsoft.AspNetCore.Mvc.Rendering;
using Skoleni.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.ViewModels
{
    public class POpravneniViewModel
    {
        public POpravneni opravneni { get; set; }
        public SelectList seznamUzivatelu { get; set; }
        public SelectList seznamRoli { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Vyberte termín")]
        public int idUzivatele { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Vyberte termín")]
        public int idRole { get; set; }
    }
}
