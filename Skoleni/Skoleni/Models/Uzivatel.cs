using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skoleni.Models
{
    public class Uzivatel
    {
        [Key]
        public int idUzivatele { get; set; }
        [Required(ErrorMessage = "Vyplňte jméno")]
        public string jmeno { get; set; }
        [Required(ErrorMessage = "Vyplňte příjmení")]
        public string prijmeni { get; set; }
        public int stredisko { get; set; }
        public string email { get; set; }

        public int idJazyka { get; set; }

        public Jazyk jazyk { get; set; }
        [Required(ErrorMessage = "Vyplňte uživatelské jméno")]
        public string nt { get; set; }
        [Required(ErrorMessage = "Vyplňte heslo")]
        public string heslo { get; set; }

        public string jmenoPrijmeni
        {
            get
            {
                return jmeno + " " + prijmeni;
            }
            
        }
    }
}
