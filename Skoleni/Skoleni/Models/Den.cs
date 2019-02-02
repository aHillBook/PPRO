using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Models
{
    public class Den
    {
        public DateTime datum { get; set; }
        public List<Zaznam> zaznamy { get; set; }
        public List<Termin> terminy { get; set; }

        public int denTydne { get; set; }

        public bool prazdny { get; set; }
        public bool nic { get; set; }
        public bool volny { get; set; }
        public bool plny { get; set; }

        public int pocetVolnychMist { get; set; }

    }
}
