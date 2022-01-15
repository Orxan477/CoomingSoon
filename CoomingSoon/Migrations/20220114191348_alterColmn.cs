using Microsoft.EntityFrameworkCore.Migrations;

namespace CoomingSoon.Migrations
{
    public partial class alterColmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Times");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Times",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Times",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Times",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Times");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Times",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
