using Microsoft.EntityFrameworkCore.Migrations;

namespace Oyuncu_Sitesi.Migrations
{
    public partial class AddAdtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdType",
                table: "Adverts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdType",
                table: "Adverts");
        }
    }
}
