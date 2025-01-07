using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrediccionSentiminetoBack.Migrations
{
    /// <inheritdoc />
    public partial class BDaddFinLineaColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Separador",
                table: "Archivo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FinLinea",
                table: "Archivo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinLinea",
                table: "Archivo");

            migrationBuilder.AlterColumn<string>(
                name: "Separador",
                table: "Archivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
