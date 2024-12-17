using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrediccionSentiminetoBack.Migrations
{
    /// <inheritdoc />
    public partial class BDComentarioEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Comentario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Comentario");
        }
    }
}
