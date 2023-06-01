using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrediccionSentiminetoBack.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ClienteId",
                table: "Comentario",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Cliente_ClienteId",
                table: "Comentario",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Cliente_ClienteId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_ClienteId",
                table: "Comentario");
        }
    }
}
