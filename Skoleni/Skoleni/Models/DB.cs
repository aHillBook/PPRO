using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Skoleni.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> moznosti) : base(moznosti) { }

        public DbSet<Uzivatel> seznamUzivatelu { get; set; }
        public DbSet<Jazyk> seznamJazyku { get; set; }
        public DbSet<Mistnost> seznamMistnosti { get; set; }
        public DbSet<Skoleni> seznamSkoleni { get; set; }
        public DbSet<Termin> seznamTerminu { get; set; }

    }
}
