using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Models
{
    public class PSkoleni
    {
        [Key]
        public int idSkoleni { get; set; }
        public string nazev { get; set; }
        public string popis { get; set; }
        public string skolitel { get; set; }



    }
}
