using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Models
{
    public class Mistnost
    {
        [Key]
        public int idMistnosti { get; set; }
        public string nazev { get; set; }
        public int kapacita { get; set; }
    }
}
