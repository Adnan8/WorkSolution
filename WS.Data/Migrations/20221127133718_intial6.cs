using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WS.Data.Migrations
{
    public partial class intial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDate",
                table: "ToDo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDate",
                table: "ToDo");
        }
    }
}
