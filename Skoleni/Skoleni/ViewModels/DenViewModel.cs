using Skoleni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.ViewModels
{
    public class DenViewModel
    {
        public string aktualniMesic { get; set; }
        public string predchoziMesic { get; set; }
        public string nasledujiciMesic { get; set; }
        public int idPredchoziMesic { get; set; }
        public int idNasledujiciMesic { get; set; }

        public int aktualniRok { get; set; }
        public int predchoziRok { get; set; }
        public int nasledujiciRok { get; set; }


        //*************************************

        public List<Den> seznam { get; set; }

        public Den d { get; set; }

        //*************************************
        public List<Termin> terminy { get; set; }

    }
}
