using Microsoft.EntityFrameworkCore.Migrations;

namespace Oyuncu_Sitesi.Migrations.ApplicationIdentityDb
{
    public partial class addUserLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BattleNetLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discord",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EpicGamesLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PsnLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statement",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SteamLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamSpeak",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XboxLink",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BattleNetLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discord",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EpicGamesLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OriginLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PsnLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Statement",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SteamLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamSpeak",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "XboxLink",
                table: "AspNetUsers");
        }
    }
}
