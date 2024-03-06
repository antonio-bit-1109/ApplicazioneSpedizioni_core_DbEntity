using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicazioneSpedizioni_core_DbEntity.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spedizioni",
                columns: table => new
                {
                    IdSpedizione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroIdentificativo = table.Column<int>(type: "int", nullable: false),
                    DataSpedizione = table.Column<DateOnly>(type: "date", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    cittaDiDestinazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndirizzoDestinatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeDestinatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoSpedizione = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataConsegnaPrevista = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spedizioni", x => x.IdSpedizione);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    IdUtente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartitaIva = table.Column<int>(type: "int", nullable: true),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attivo = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.IdUtente);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spedizioni_NumeroIdentificativo",
                table: "Spedizioni",
                column: "NumeroIdentificativo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spedizioni");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
