using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class addedVisitas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Socios = table.Column<int>(type: "int", nullable: false),
                    Dependientes = table.Column<int>(type: "int", nullable: false),
                    Huespedes = table.Column<int>(type: "int", nullable: false),
                    Adicionales = table.Column<int>(type: "int", nullable: false),
                    Invitados = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitasInvitado",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasInvitado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitasSocio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CantidadPrincipal = table.Column<int>(type: "int", nullable: false),
                    CantidadDependientes = table.Column<int>(type: "int", nullable: false),
                    CantidadAdicionales = table.Column<int>(type: "int", nullable: false),
                    CantidadHuespedes = table.Column<int>(type: "int", nullable: false),
                    CantidadInvitados = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasSocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitasSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitasInvitado_NumeroIdentidad",
                table: "VisitasInvitado",
                column: "NumeroIdentidad");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasSocio_SocioId",
                table: "VisitasSocio",
                column: "SocioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "VisitasInvitado");

            migrationBuilder.DropTable(
                name: "VisitasSocio");
        }
    }
}
