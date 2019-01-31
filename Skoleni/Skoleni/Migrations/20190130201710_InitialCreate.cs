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
                name: "seznamOpravneni",
                columns: table => new
                {
                    idUzivatele = table.Column<int>(nullable: false),
                    idRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamOpravneni", x => new { x.idUzivatele, x.idRole });
                    table.UniqueConstraint("AK_seznamOpravneni_idRole_idUzivatele", x => new { x.idRole, x.idUzivatele });
                });

            migrationBuilder.CreateTable(
                name: "seznamRoli",
                columns: table => new
                {
                    idJazyka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazev = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamRoli", x => x.idJazyka);
                });

            migrationBuilder.CreateTable(
                name: "seznamSkoleni",
                columns: table => new
                {
                    idSkoleni = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazev = table.Column<string>(nullable: true),
                    popis = table.Column<string>(nullable: true)
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
                    idJazyka = table.Column<int>(nullable: false),
                    nt = table.Column<string>(nullable: true),
                    heslo = table.Column<string>(nullable: true)
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
                    idJazyka = table.Column<int>(nullable: false),
                    idSkoleni = table.Column<int>(nullable: false),
                    idMistnosti = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamTerminu", x => x.idTerminu);
                    table.ForeignKey(
                        name: "FK_seznamTerminu_seznamJazyku_idJazyka",
                        column: x => x.idJazyka,
                        principalTable: "seznamJazyku",
                        principalColumn: "idJazyka",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seznamTerminu_seznamMistnosti_idMistnosti",
                        column: x => x.idMistnosti,
                        principalTable: "seznamMistnosti",
                        principalColumn: "idMistnosti",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seznamTerminu_seznamSkoleni_idSkoleni",
                        column: x => x.idSkoleni,
                        principalTable: "seznamSkoleni",
                        principalColumn: "idSkoleni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seznamZaznamu",
                columns: table => new
                {
                    idZaznamu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idTerminu = table.Column<int>(nullable: false),
                    idUzivatele = table.Column<int>(nullable: false),
                    datumPrihlaseni = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seznamZaznamu", x => x.idZaznamu);
                    table.ForeignKey(
                        name: "FK_seznamZaznamu_seznamTerminu_idTerminu",
                        column: x => x.idTerminu,
                        principalTable: "seznamTerminu",
                        principalColumn: "idTerminu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seznamZaznamu_seznamUzivatelu_idUzivatele",
                        column: x => x.idUzivatele,
                        principalTable: "seznamUzivatelu",
                        principalColumn: "idUzivatele",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_seznamTerminu_idJazyka",
                table: "seznamTerminu",
                column: "idJazyka");

            migrationBuilder.CreateIndex(
                name: "IX_seznamTerminu_idMistnosti",
                table: "seznamTerminu",
                column: "idMistnosti");

            migrationBuilder.CreateIndex(
                name: "IX_seznamTerminu_idSkoleni",
                table: "seznamTerminu",
                column: "idSkoleni");

            migrationBuilder.CreateIndex(
                name: "IX_seznamUzivatelu_idJazyka",
                table: "seznamUzivatelu",
                column: "idJazyka");

            migrationBuilder.CreateIndex(
                name: "IX_seznamZaznamu_idTerminu",
                table: "seznamZaznamu",
                column: "idTerminu");

            migrationBuilder.CreateIndex(
                name: "IX_seznamZaznamu_idUzivatele",
                table: "seznamZaznamu",
                column: "idUzivatele");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "seznamOpravneni");

            migrationBuilder.DropTable(
                name: "seznamRoli");

            migrationBuilder.DropTable(
                name: "seznamZaznamu");

            migrationBuilder.DropTable(
                name: "seznamTerminu");

            migrationBuilder.DropTable(
                name: "seznamUzivatelu");

            migrationBuilder.DropTable(
                name: "seznamMistnosti");

            migrationBuilder.DropTable(
                name: "seznamSkoleni");

            migrationBuilder.DropTable(
                name: "seznamJazyku");
        }
    }
}
