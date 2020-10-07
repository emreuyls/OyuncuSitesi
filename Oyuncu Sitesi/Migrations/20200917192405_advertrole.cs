using Microsoft.EntityFrameworkCore.Migrations;

namespace Oyuncu_Sitesi.Migrations
{
    public partial class advertrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertRole_Roles_RolesID",
                table: "AdvertRole");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRole_Games_GamesID",
                table: "GameRole");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRole_Roles_RolesID",
                table: "GameRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameRole",
                table: "GameRole");

            migrationBuilder.DropIndex(
                name: "IX_GameRole_GamesID",
                table: "GameRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertRole",
                table: "AdvertRole");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "GameRole");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "GameRole");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AdvertRole");

            migrationBuilder.AlterColumn<int>(
                name: "RolesID",
                table: "GameRole",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GamesID",
                table: "GameRole",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RolesID",
                table: "AdvertRole",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameRole",
                table: "GameRole",
                columns: new[] { "GamesID", "RolesID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertRole",
                table: "AdvertRole",
                columns: new[] { "AdvertID", "RolesID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertRole_Roles_RolesID",
                table: "AdvertRole",
                column: "RolesID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRole_Games_GamesID",
                table: "GameRole",
                column: "GamesID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRole_Roles_RolesID",
                table: "GameRole",
                column: "RolesID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertRole_Roles_RolesID",
                table: "AdvertRole");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRole_Games_GamesID",
                table: "GameRole");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRole_Roles_RolesID",
                table: "GameRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameRole",
                table: "GameRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertRole",
                table: "AdvertRole");

            migrationBuilder.AlterColumn<int>(
                name: "RolesID",
                table: "GameRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GamesID",
                table: "GameRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "GameRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "GameRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RolesID",
                table: "AdvertRole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AdvertRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameRole",
                table: "GameRole",
                columns: new[] { "GameID", "RoleID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertRole",
                table: "AdvertRole",
                columns: new[] { "AdvertID", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_GameRole_GamesID",
                table: "GameRole",
                column: "GamesID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertRole_Roles_RolesID",
                table: "AdvertRole",
                column: "RolesID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRole_Games_GamesID",
                table: "GameRole",
                column: "GamesID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRole_Roles_RolesID",
                table: "GameRole",
                column: "RolesID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
