using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicazioneSpedizioni_core_DbEntity.Migrations
{
    /// <inheritdoc />
    public partial class aggiuntachiaveesternaNullableTabellaSpedizioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUtente",
                table: "Spedizioni",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spedizioni_IdUtente",
                table: "Spedizioni",
                column: "IdUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_Spedizioni_Utenti_IdUtente",
                table: "Spedizioni",
                column: "IdUtente",
                principalTable: "Utenti",
                principalColumn: "IdUtente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spedizioni_Utenti_IdUtente",
                table: "Spedizioni");

            migrationBuilder.DropIndex(
                name: "IX_Spedizioni_IdUtente",
                table: "Spedizioni");

            migrationBuilder.DropColumn(
                name: "IdUtente",
                table: "Spedizioni");
        }
    }
}
