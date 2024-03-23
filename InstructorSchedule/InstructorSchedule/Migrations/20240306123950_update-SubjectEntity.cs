using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrasctructrue.Migrations
{
    public partial class updateSubjectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Subjects");
        }
    }
}
