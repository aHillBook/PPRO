using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skoleni.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "seznamJazyku",
                columns: table => new
                {
                    idJazyka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazev = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamJazyku", x => x.idJazyka);
                });

            migrationBuilder.CreateTable(
                name: "seznamMistnosti",
                columns: table => new
                {
                    idMistnosti = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazev = table.Column<string>(nullable: true),
                    kapacita = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamMistnosti", x => x.idMistnosti);
                });

            migrationBuilder.CreateTable(
                name: "seznamSkoleni",
                columns: table => new
                {
                    idSkoleni = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazev = table.Column<string>(nullable: true),
                    popis = table.Column<string>(nullable: true),
                    skolitel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamSkoleni", x => x.idSkoleni);
                });

            migrationBuilder.CreateTable(
                name: "seznamUzivatelu",
                columns: table => new
                {
                    idUzivatele = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    jmeno = table.Column<string>(nullable: true),
                    prijmeni = table.Column<string>(nullable: true),
                    stredisko = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    idJazyka = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamUzivatelu", x => x.idUzivatele);
                    table.ForeignKey(
                        name: "FK_seznamUzivatelu_seznamJazyku_idJazyka",
                        column: x => x.idJazyka,
                        principalTable: "seznamJazyku",
                        principalColumn: "idJazyka",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seznamTerminu",
                columns: table => new
                {
                    idTerminu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    terminKonani = table.Column<DateTime>(nullable: false),
                    dobaTrvani = table.Column<int>(nullable: false),
                    skoleniidSkoleni = table.Column<int>(nullable: true),
                    jazykidJazyka = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamTerminu", x => x.idTerminu);
                    table.ForeignKey(
                        name: "FK_seznamTerminu_seznamJazyku_jazykidJazyka",
                        column: x => x.jazykidJazyka,
                        principalTable: "seznamJazyku",
                        principalColumn: "idJazyka",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_seznamTerminu_seznamSkoleni_skoleniidSkoleni",
                        column: x => x.skoleniidSkoleni,
                        principalTable: "seznamSkoleni",
                        principalColumn: "idSkoleni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_seznamTerminu_jazykidJazyka",
                table: "seznamTerminu",
                column: "jazykidJazyka");

            migrationBuilder.CreateIndex(
                name: "IX_seznamTerminu_skoleniidSkoleni",
                table: "seznamTerminu",
                column: "skoleniidSkoleni");

            migrationBuilder.CreateIndex(
                name: "IX_seznamUzivatelu_idJazyka",
                table: "seznamUzivatelu",
                column: "idJazyka");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "seznamMistnosti");

            migrationBuilder.DropTable(
                name: "seznamTerminu");

            migrationBuilder.DropTable(
                name: "seznamUzivatelu");

            migrationBuilder.DropTable(
                name: "seznamSkoleni");

            migrationBuilder.DropTable(
                name: "seznamJazyku");
        }
    }
}
