using Microsoft.AspNetCore.Mvc.Rendering;
using Skoleni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.ViewModels
{
    public class UzivatelViewModel
    {
        public SelectList seznamJazyku { get; set; }
        public Uzivatel uzivatel { get; set; }
    }
}
