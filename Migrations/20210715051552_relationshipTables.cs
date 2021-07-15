using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BryantCornerCafe.Migrations
{
    public partial class relationshipTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_SubCategories_SubCategoryId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "UDRels");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CSubRels",
                columns: table => new
                {
                    CSubRelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSubRels", x => x.CSubRelId);
                    table.ForeignKey(
                        name: "FK_CSubRels_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CSubRels_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubDRels",
                columns: table => new
                {
                    SubDRelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDRels", x => x.SubDRelId);
                    table.ForeignKey(
                        name: "FK_SubDRels_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDRels_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CSubRels_CategoryId",
                table: "CSubRels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CSubRels_SubCategoryId",
                table: "CSubRels",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDRels_DishId",
                table: "SubDRels",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDRels_SubCategoryId",
                table: "SubDRels",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_SubCategories_SubCategoryId",
                table: "Dishes",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_SubCategories_SubCategoryId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "CSubRels");

            migrationBuilder.DropTable(
                name: "SubDRels");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "Dishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UDRels",
                columns: table => new
                {
                    UDRelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UDRels", x => x.UDRelId);
                    table.ForeignKey(
                        name: "FK_UDRels_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UDRels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UDRels_DishId",
                table: "UDRels",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_UDRels_UserId",
                table: "UDRels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_SubCategories_SubCategoryId",
                table: "Dishes",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
