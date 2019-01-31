using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skoleni.Models
{
    public class POpravneni
    {
        [Key, Column(Order = 0)]
        public int idUzivatele { get; set; }
        [Key, Column(Order = 1)]
        public int idRole { get; set; }
        
        Uzivatel uzivatel { get; set; }
        PRole role { get; set; }
    }
}
