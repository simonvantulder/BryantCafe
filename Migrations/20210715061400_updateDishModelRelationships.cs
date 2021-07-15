using Microsoft.EntityFrameworkCore.Migrations;

namespace BryantCornerCafe.Migrations
{
    public partial class updateDishModelRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Users_ChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_UserId",
                table: "Dishes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Users_UserId",
                table: "Dishes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Users_UserId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_UserId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "ChefId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Users_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
