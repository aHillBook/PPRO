using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Skoleni.Models
{
    public class PRole
    {
        [Key]
        public int idJazyka { get; set; }
        public string nazev { get; set; }
    }
}
