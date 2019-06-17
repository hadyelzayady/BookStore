using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class chagenFKname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_CategoriesParents_CategoryParentId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CategoryParentId",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryParentId",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CategoriesParents_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "CategoriesParents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_CategoriesParents_CategoryId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "CategoryParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                newName: "IX_Books_CategoryParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CategoriesParents_CategoryParentId",
                table: "Books",
                column: "CategoryParentId",
                principalTable: "CategoriesParents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
