using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class addedTipoSocioyCoretesias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SocioId",
                table: "Socio",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Localidad",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Localidad",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Bloqueado",
                table: "Instalacion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "BloqueadoDesde",
                table: "Instalacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BloqueadoHasta",
                table: "Instalacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BloqueadoRazon",
                table: "Instalacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socio_SocioId",
                table: "Socio",
                column: "SocioId",
                unique: true,
                filter: "[SocioId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Socio_SocioId",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "SocioId",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Localidad");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Localidad");

            migrationBuilder.DropColumn(
                name: "Bloqueado",
                table: "Instalacion");

            migrationBuilder.DropColumn(
                name: "BloqueadoDesde",
                table: "Instalacion");

            migrationBuilder.DropColumn(
                name: "BloqueadoHasta",
                table: "Instalacion");

            migrationBuilder.DropColumn(
                name: "BloqueadoRazon",
                table: "Instalacion");
        }
    }
}
