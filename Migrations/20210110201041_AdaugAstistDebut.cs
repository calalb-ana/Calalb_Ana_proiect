using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calalb_Ana_proiect.Migrations
{
    public partial class AdaugAstistDebut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Debut",
                table: "Artist",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debut",
                table: "Artist");
        }
    }
}
