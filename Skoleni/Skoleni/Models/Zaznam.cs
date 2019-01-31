using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Skoleni.Models
{
    public class Zaznam
    {
        [Key]
        public int idZaznamu { get; set; }
        public int idTerminu { get; set; }
        public int idUzivatele { get; set; }
        public DateTime datumPrihlaseni { get; set; }

        public Termin termin { get; set; }
        public Uzivatel uzivatel { get; set; }
    }
}
