using Microsoft.EntityFrameworkCore.Migrations;

namespace LAB19CreateAnAPI.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_TodoList_TodoListId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_TodoListId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "TodoListId",
                table: "Todos");

            migrationBuilder.AlterColumn<long>(
                name: "ListId",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Todos_ListId",
                table: "Todos",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_TodoList_ListId",
                table: "Todos",
                column: "ListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_TodoList_ListId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_ListId",
                table: "Todos");

            migrationBuilder.AlterColumn<int>(
                name: "ListId",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "TodoListId",
                table: "Todos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_TodoListId",
                table: "Todos",
                column: "TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_TodoList_TodoListId",
                table: "Todos",
                column: "TodoListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
