using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class AmmendInvitacionSocioPorSolicitud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SolicitudId",
                table: "InvitacionDeSocio",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InvitacionDeSocio_FechaHoraVisita",
                table: "InvitacionDeSocio",
                column: "FechaHoraVisita");

            migrationBuilder.CreateIndex(
                name: "IX_InvitacionDeSocio_SolicitudId",
                table: "InvitacionDeSocio",
                column: "SolicitudId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvitacionDeSocio_FechaHoraVisita",
                table: "InvitacionDeSocio");

            migrationBuilder.DropIndex(
                name: "IX_InvitacionDeSocio_SolicitudId",
                table: "InvitacionDeSocio");

            migrationBuilder.DropColumn(
                name: "SolicitudId",
                table: "InvitacionDeSocio");
        }
    }
}
