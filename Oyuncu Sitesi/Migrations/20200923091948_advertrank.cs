using Microsoft.EntityFrameworkCore.Migrations;

namespace Oyuncu_Sitesi.Migrations
{
    public partial class advertrank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Adverts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdvertRank",
                columns: table => new
                {
                    AdvertID = table.Column<int>(nullable: false),
                    RankID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertRank", x => new { x.AdvertID, x.RankID });
                    table.ForeignKey(
                        name: "FK_AdvertRank_Adverts_AdvertID",
                        column: x => x.AdvertID,
                        principalTable: "Adverts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertRank_Rank_RankID",
                        column: x => x.RankID,
                        principalTable: "Rank",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertRank_RankID",
                table: "AdvertRank",
                column: "RankID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertRank");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Adverts");
        }
    }
}
