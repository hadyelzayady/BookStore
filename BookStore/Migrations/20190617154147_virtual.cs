using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class @virtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents",
                columns: new[] { "CategoryId", "ParentCategoryId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents",
                columns: new[] { "CategoryId", "ParentCategoryId" });
        }
    }
}
