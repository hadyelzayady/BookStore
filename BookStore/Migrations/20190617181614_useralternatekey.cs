using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class useralternatekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents",
                columns: new[] { "CategoryId", "ParentCategoryId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents",
                columns: new[] { "CategoryId", "ParentCategoryId" },
                unique: true);
        }
    }
}
