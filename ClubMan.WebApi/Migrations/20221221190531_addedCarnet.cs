using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class addedCarnet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carnet",
                columns: table => new
                {
                    CarnetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    ReferenciaId = table.Column<long>(type: "bigint", nullable: false),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiasValidez = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carnet", x => x.CarnetId);
                    table.ForeignKey(
                        name: "FK_Carnet_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carnet_SocioId",
                table: "Carnet",
                column: "SocioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carnet");
        }
    }
}
