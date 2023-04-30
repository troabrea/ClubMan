using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class AddedVisitaManual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitaManual",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PorteroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivoVisita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitaManual", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitaManual_FechaHora",
                table: "VisitaManual",
                column: "FechaHora");

            migrationBuilder.CreateIndex(
                name: "IX_VisitaManual_PorteroId",
                table: "VisitaManual",
                column: "PorteroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitaManual");
        }
    }
}
