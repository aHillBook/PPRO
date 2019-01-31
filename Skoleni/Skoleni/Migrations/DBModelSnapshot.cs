﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skoleni.Models;

namespace Skoleni.Migrations
{
    [DbContext(typeof(DB))]
    partial class DBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Skoleni.Models.Jazyk", b =>
                {
                    b.Property<int>("idJazyka")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazev");

                    b.HasKey("idJazyka");

                    b.ToTable("seznamJazyku");
                });

            modelBuilder.Entity("Skoleni.Models.Mistnost", b =>
                {
                    b.Property<int>("idMistnosti")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("kapacita");

                    b.Property<string>("nazev");

                    b.HasKey("idMistnosti");

                    b.ToTable("seznamMistnosti");
                });

            modelBuilder.Entity("Skoleni.Models.POpravneni", b =>
                {
                    b.Property<int>("idUzivatele");

                    b.Property<int>("idRole");

                    b.HasKey("idUzivatele", "idRole");

                    b.HasAlternateKey("idRole", "idUzivatele");

                    b.ToTable("seznamOpravneni");
                });

            modelBuilder.Entity("Skoleni.Models.PRole", b =>
                {
                    b.Property<int>("idRole")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazev");

                    b.HasKey("idRole");

                    b.ToTable("seznamRoli");
                });

            modelBuilder.Entity("Skoleni.Models.PSkoleni", b =>
                {
                    b.Property<int>("idSkoleni")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazev");

                    b.Property<string>("popis");

                    b.HasKey("idSkoleni");

                    b.ToTable("seznamSkoleni");
                });

            modelBuilder.Entity("Skoleni.Models.Termin", b =>
                {
                    b.Property<int>("idTerminu")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("dobaTrvani");

                    b.Property<int>("idJazyka");

                    b.Property<int>("idMistnosti");

                    b.Property<int>("idSkoleni");

                    b.Property<DateTime>("terminKonani");

                    b.HasKey("idTerminu");

                    b.HasIndex("idJazyka");

                    b.HasIndex("idMistnosti");

                    b.HasIndex("idSkoleni");

                    b.ToTable("seznamTerminu");
                });

            modelBuilder.Entity("Skoleni.Models.Uzivatel", b =>
                {
                    b.Property<int>("idUzivatele")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("heslo");

                    b.Property<int>("idRole");

                    b.Property<string>("jmeno");

                    b.Property<string>("nt");

                    b.Property<string>("prijmeni");

                    b.Property<int>("stredisko");

                    b.HasKey("idUzivatele");

                    b.HasIndex("idRole");

                    b.ToTable("seznamUzivatelu");
                });

            modelBuilder.Entity("Skoleni.Models.Zaznam", b =>
                {
                    b.Property<int>("idZaznamu")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datumPrihlaseni");

                    b.Property<int>("idTerminu");

                    b.Property<int>("idUzivatele");

                    b.HasKey("idZaznamu");

                    b.HasIndex("idTerminu");

                    b.HasIndex("idUzivatele");

                    b.ToTable("seznamZaznamu");
                });

            modelBuilder.Entity("Skoleni.Models.Termin", b =>
                {
                    b.HasOne("Skoleni.Models.Jazyk", "jazyk")
                        .WithMany()
                        .HasForeignKey("idJazyka")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Skoleni.Models.Mistnost", "mistnost")
                        .WithMany()
                        .HasForeignKey("idMistnosti")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Skoleni.Models.PSkoleni", "skoleni")
                        .WithMany()
                        .HasForeignKey("idSkoleni")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Skoleni.Models.Uzivatel", b =>
                {
                    b.HasOne("Skoleni.Models.Jazyk", "jazyk")
                        .WithMany()
                        .HasForeignKey("idJazyka")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Skoleni.Models.Zaznam", b =>
                {
                    b.HasOne("Skoleni.Models.Termin", "termin")
                        .WithMany()
                        .HasForeignKey("idTerminu")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Skoleni.Models.Uzivatel", "uzivatel")
                        .WithMany()
                        .HasForeignKey("idUzivatele")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
