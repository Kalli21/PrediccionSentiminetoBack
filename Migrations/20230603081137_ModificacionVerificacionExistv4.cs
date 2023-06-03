using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrediccionSentiminetoBack.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionVerificacionExistv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodProduct",
                table: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "CodProducto",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CodCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodProducto",
                table: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "CodProduct",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
