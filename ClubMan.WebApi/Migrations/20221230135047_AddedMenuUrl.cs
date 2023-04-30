using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class AddedMenuUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MenuUrl",
                table: "Instalacion",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuUrl",
                table: "Instalacion");
        }
    }
}
