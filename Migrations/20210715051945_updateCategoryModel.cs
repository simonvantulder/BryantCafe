using Microsoft.EntityFrameworkCore.Migrations;

namespace BryantCornerCafe.Migrations
{
    public partial class updateCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoursAvailable",
                table: "Categories",
                newName: "Info");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Info",
                table: "Categories",
                newName: "HoursAvailable");
        }
    }
}
