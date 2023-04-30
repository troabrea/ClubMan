using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class AdditionalEmbarcacionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Solcitud_Embarcaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Solcitud_Embarcaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermisoNavegacion",
                table: "Solcitud_Embarcaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seguro",
                table: "Solcitud_Embarcaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Socio_Embarcaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Socio_Embarcaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermisoNavegacion",
                table: "Socio_Embarcaciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seguro",
                table: "Socio_Embarcaciones",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Solcitud_Embarcaciones");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Solcitud_Embarcaciones");

            migrationBuilder.DropColumn(
                name: "PermisoNavegacion",
                table: "Solcitud_Embarcaciones");

            migrationBuilder.DropColumn(
                name: "Seguro",
                table: "Solcitud_Embarcaciones");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Socio_Embarcaciones");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Socio_Embarcaciones");

            migrationBuilder.DropColumn(
                name: "PermisoNavegacion",
                table: "Socio_Embarcaciones");

            migrationBuilder.DropColumn(
                name: "Seguro",
                table: "Socio_Embarcaciones");
        }
    }
}
