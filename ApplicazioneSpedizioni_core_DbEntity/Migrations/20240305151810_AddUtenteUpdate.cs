using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicazioneSpedizioni_core_DbEntity.Migrations
{
    /// <inheritdoc />
    public partial class AddUtenteUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Attivo",
                table: "Utenti",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attivo",
                table: "Utenti");
        }
    }
}
