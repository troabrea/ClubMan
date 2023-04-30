using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class ReservasPagadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadAcciones",
                table: "Socio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CostoReserva",
                table: "Instalacion",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Instalacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Costo",
                table: "EventoDeSocio",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "EventoDeSocio",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Pagado",
                table: "EventoDeSocio",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReferenciaPago",
                table: "EventoDeSocio",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadAcciones",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "CostoReserva",
                table: "Instalacion");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Instalacion");

            migrationBuilder.DropColumn(
                name: "Costo",
                table: "EventoDeSocio");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "EventoDeSocio");

            migrationBuilder.DropColumn(
                name: "Pagado",
                table: "EventoDeSocio");

            migrationBuilder.DropColumn(
                name: "ReferenciaPago",
                table: "EventoDeSocio");
        }
    }
}
