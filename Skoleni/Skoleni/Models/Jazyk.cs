using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Models
{
    public class Jazyk
    {
        [Key]
        public int idJazyka { get; set; }
        [Required(ErrorMessage = "Vyplňte název")]
        public string nazev { get; set; }
    }
}
