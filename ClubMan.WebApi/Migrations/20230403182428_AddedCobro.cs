using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class AddedCobro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    Carnet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estatus = table.Column<short>(type: "smallint", nullable: false),
                    NumeroConfirmacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CobroAplicacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobroId = table.Column<long>(type: "bigint", nullable: false),
                    IdDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroAplicacion", x => new { x.CobroId, x.Id });
                    table.ForeignKey(
                        name: "FK_CobroAplicacion_Cobro_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobroAplicacion");

            migrationBuilder.DropTable(
                name: "Cobro");
        }
    }
}
