using Microsoft.EntityFrameworkCore.Migrations;

namespace BryantCornerCafe.Migrations
{
    public partial class updateSubCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "SubCategories",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "SubCategories");
        }
    }
}
