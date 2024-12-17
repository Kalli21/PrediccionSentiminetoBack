using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrediccionSentiminetoBack.Migrations
{
    /// <inheritdoc />
    public partial class BDArchivoCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Separador",
                table: "Archivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Separador",
                table: "Archivo");
        }
    }
}
