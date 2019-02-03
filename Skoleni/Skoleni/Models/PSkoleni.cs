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
        [Required(ErrorMessage = "Vyplňte název")]
        public string nazev { get; set; }
        [Required(ErrorMessage = "Vyplňte popis")]
        public string popis { get; set; }

    }
}
