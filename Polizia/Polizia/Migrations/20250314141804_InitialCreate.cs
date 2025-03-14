using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polizia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafiche",
                columns: table => new
                {
                    IdAnagrafica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cod_Fisc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafiche", x => x.IdAnagrafica);
                });

            migrationBuilder.CreateTable(
                name: "TipiViolazione",
                columns: table => new
                {
                    IdViolazione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipiViolazione", x => x.IdViolazione);
                });

            migrationBuilder.CreateTable(
                name: "Verbali",
                columns: table => new
                {
                    IdVerbale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnagrafica = table.Column<int>(type: "int", nullable: false),
                    IdViolazione = table.Column<int>(type: "int", nullable: false),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nominativo_Agente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataTrascrizioneVerbale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbali", x => x.IdVerbale);
                    table.ForeignKey(
                        name: "FK_Verbali_Anagrafiche_IdAnagrafica",
                        column: x => x.IdAnagrafica,
                        principalTable: "Anagrafiche",
                        principalColumn: "IdAnagrafica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbali_TipiViolazione_IdViolazione",
                        column: x => x.IdViolazione,
                        principalTable: "TipiViolazione",
                        principalColumn: "IdViolazione",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_IdAnagrafica",
                table: "Verbali",
                column: "IdAnagrafica");

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_IdViolazione",
                table: "Verbali",
                column: "IdViolazione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbali");

            migrationBuilder.DropTable(
                name: "Anagrafiche");

            migrationBuilder.DropTable(
                name: "TipiViolazione");
        }
    }
}
