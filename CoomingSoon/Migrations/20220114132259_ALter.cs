using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoomingSoon.Migrations
{
    public partial class ALter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Second",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Times");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Times",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Times");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Times",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "Times",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Second",
                table: "Times",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Times",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
