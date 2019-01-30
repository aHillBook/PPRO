using Microsoft.AspNetCore.Mvc.Rendering;
using Skoleni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.ViewModels
{
    public class TerminViewModel
    {
        public List<Termin> seznamTerminu { get; set; }

        public Termin termin { get; set; }

        public SelectList seznamSkoleni { get; set; }

        public SelectList seznamJazyku { get; set; }
    }
}
