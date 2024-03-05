using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicazioneSpedizioni_core_DbEntity.Migrations
{
    /// <inheritdoc />
    public partial class deletetabella : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtentiCredenzialiAccesso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UtentiCredenzialiAccesso",
                columns: table => new
                {
                    IdUtente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtentiCredenzialiAccesso", x => x.IdUtente);
                });
        }
    }
}
