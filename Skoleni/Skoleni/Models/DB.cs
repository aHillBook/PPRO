using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Skoleni.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> moznosti) : base(moznosti) { }

        public DbSet<Jazyk> seznamJazyku { get; set; }
        public DbSet<Mistnost> seznamMistnosti { get; set; }
        public DbSet<POpravneni> seznamOpravneni { get; set; }
        public DbSet<PRole> seznamRoli { get; set; }
        public DbSet<PSkoleni> seznamSkoleni { get; set; }
        public DbSet<Termin> seznamTerminu { get; set; }
        public DbSet<Uzivatel> seznamUzivatelu { get; set; }
        public DbSet<Zaznam> seznamZaznamu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<POpravneni>()
                .HasKey(c => new { c.idUzivatele, c.idRole });
        }

    }
}
