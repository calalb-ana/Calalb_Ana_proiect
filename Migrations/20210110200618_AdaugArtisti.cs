using Microsoft.EntityFrameworkCore.Migrations;

namespace Calalb_Ana_proiect.Migrations
{
    public partial class AdaugArtisti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "Album",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistID",
                table: "Album",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistID",
                table: "Album",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistID",
                table: "Album");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Album_ArtistID",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "Album");
        }
    }
}
