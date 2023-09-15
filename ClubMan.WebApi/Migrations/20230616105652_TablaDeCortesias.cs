using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class TablaDeCortesias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cortesia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarnet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugarTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoOficina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoFlota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAsistente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAsitente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cortesia", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cortesia_Id",
                table: "Cortesia",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cortesia");
        }
    }
}
