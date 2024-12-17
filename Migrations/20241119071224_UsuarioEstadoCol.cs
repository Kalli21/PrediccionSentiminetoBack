﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrediccionSentiminetoBack.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioEstadoCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Usuario");
        }
    }
}
