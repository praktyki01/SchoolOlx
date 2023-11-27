using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolOlx.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKategori = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klasa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wydawnictwo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawnictwo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprzedajacy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KlasaId = table.Column<int>(type: "int", nullable: false),
                    DaneKontaktowe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzedajacy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprzedajacy_Klasa_KlasaId",
                        column: x => x.KlasaId,
                        principalTable: "Klasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogloszenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaOgloszenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StanId = table.Column<int>(type: "int", nullable: false),
                    Zdjecie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<float>(type: "real", nullable: false),
                    KlasaId = table.Column<int>(type: "int", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false),
                    WydawnictwoId = table.Column<int>(type: "int", nullable: false),
                    SprzedajacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogloszenia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogloszenia_Kategoria_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ogloszenia_Klasa_KlasaId",
                        column: x => x.KlasaId,
                        principalTable: "Klasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ogloszenia_Sprzedajacy_SprzedajacyId",
                        column: x => x.SprzedajacyId,
                        principalTable: "Sprzedajacy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ogloszenia_Stan_StanId",
                        column: x => x.StanId,
                        principalTable: "Stan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ogloszenia_Wydawnictwo_WydawnictwoId",
                        column: x => x.WydawnictwoId,
                        principalTable: "Wydawnictwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogloszenia_KategoriaId",
                table: "Ogloszenia",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogloszenia_KlasaId",
                table: "Ogloszenia",
                column: "KlasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogloszenia_SprzedajacyId",
                table: "Ogloszenia",
                column: "SprzedajacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogloszenia_StanId",
                table: "Ogloszenia",
                column: "StanId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogloszenia_WydawnictwoId",
                table: "Ogloszenia",
                column: "WydawnictwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzedajacy_KlasaId",
                table: "Sprzedajacy",
                column: "KlasaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ogloszenia");

            migrationBuilder.DropTable(
                name: "Kategoria");

            migrationBuilder.DropTable(
                name: "Sprzedajacy");

            migrationBuilder.DropTable(
                name: "Stan");

            migrationBuilder.DropTable(
                name: "Wydawnictwo");

            migrationBuilder.DropTable(
                name: "Klasa");
        }
    }
}
