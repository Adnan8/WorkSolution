using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WS.Data.Migrations
{
    public partial class intial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ToDo_StatusId",
                table: "ToDo",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_ToDoStatus_StatusId",
                table: "ToDo",
                column: "StatusId",
                principalTable: "ToDoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_ToDoStatus_StatusId",
                table: "ToDo");

            migrationBuilder.DropIndex(
                name: "IX_ToDo_StatusId",
                table: "ToDo");
        }
    }
}
