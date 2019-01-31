using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Models
{
    public class Termin
    {
        [Key]
        public int idTerminu { get; set; }
        public DateTime terminKonani { get; set; }
        public int dobaTrvani { get; set; }

        public int idJazyka { get; set; }
        public int idSkoleni { get; set;  }
        public int idMistnosti { get; set; }

        public PSkoleni skoleni { get; set; }
        public Jazyk jazyk { get; set; }
        public Mistnost mistnost { get; set; }

    }
}
