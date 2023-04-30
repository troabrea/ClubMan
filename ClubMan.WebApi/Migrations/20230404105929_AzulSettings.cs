using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class AzulSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthKey",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantName",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantType",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SandboxServiceUrl",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceUrl",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseSandbox",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTarjeta",
                table: "Cobro",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthKey",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "MerchantName",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "MerchantType",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "SandboxServiceUrl",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ServiceUrl",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "UseSandbox",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "NumeroTarjeta",
                table: "Cobro");
        }
    }
}
