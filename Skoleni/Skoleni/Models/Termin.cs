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
        [DisplayFormat(DataFormatString = @"{0:dd\.MM\.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime terminKonani { get; set; }
        [Required(ErrorMessage = "Vyplňte kapacitu")]
        [Range(1, 600, ErrorMessage = "Doba trvání musí být větší jak 0")]
        public int dobaTrvani { get; set; }

        public int idJazyka { get; set; }
        public int idSkoleni { get; set;  }
        public int idMistnosti { get; set; }

        public PSkoleni skoleni { get; set; }
        public Jazyk jazyk { get; set; }
        public Mistnost mistnost { get; set; }

    }
}
