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
        [Required(ErrorMessage = "Vyplňte název")]
        public string nazev { get; set; }
        [Required(ErrorMessage = "Vyplňte kapacitu")]
        [Range(1, 600, ErrorMessage = "Kapacita musí být větší jak 0")]
        public int kapacita { get; set; }
    }
}
