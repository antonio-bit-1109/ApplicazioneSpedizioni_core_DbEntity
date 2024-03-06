using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicazioneSpedizioni_core_DbEntity.Migrations
{
    /// <inheritdoc />
    public partial class tabellaStatoSpedizioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatoSpedizioni",
                columns: table => new
                {
                    IdStatoSpedizione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusSpedizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LuogoGiacenzaPacco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAggiornamento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdSpedizione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatoSpedizioni", x => x.IdStatoSpedizione);
                    table.ForeignKey(
                        name: "FK_StatoSpedizioni_Spedizioni_IdSpedizione",
                        column: x => x.IdSpedizione,
                        principalTable: "Spedizioni",
                        principalColumn: "IdSpedizione",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatoSpedizioni_IdSpedizione",
                table: "StatoSpedizioni",
                column: "IdSpedizione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatoSpedizioni");
        }
    }
}
