using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicazioneSpedizioni_core_DbEntity.Migrations
{
    /// <inheritdoc />
    public partial class Update20Utenti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Utenti",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Utenti");
        }
    }
}
