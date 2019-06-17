using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class parent_categ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_CategoryParent_CategoryParentId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryParent_Category_CategoryId",
                table: "CategoryParent");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryParent_Category_ParentCategoryId",
                table: "CategoryParent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryParent",
                table: "CategoryParent");

            migrationBuilder.DropIndex(
                name: "IX_CategoryParent_CategoryId",
                table: "CategoryParent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "CategoryParent",
                newName: "CategoriesParents");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryParent_ParentCategoryId",
                table: "CategoriesParents",
                newName: "IX_CategoriesParents_ParentCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesParents",
                table: "CategoriesParents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents",
                columns: new[] { "CategoryId", "ParentCategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CategoriesParents_CategoryParentId",
                table: "Books",
                column: "CategoryParentId",
                principalTable: "CategoriesParents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesParents_Categories_CategoryId",
                table: "CategoriesParents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesParents_Categories_ParentCategoryId",
                table: "CategoriesParents",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_CategoriesParents_CategoryParentId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesParents_Categories_CategoryId",
                table: "CategoriesParents");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesParents_Categories_ParentCategoryId",
                table: "CategoriesParents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesParents",
                table: "CategoriesParents");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesParents_CategoryId_ParentCategoryId",
                table: "CategoriesParents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "CategoriesParents",
                newName: "CategoryParent");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriesParents_ParentCategoryId",
                table: "CategoryParent",
                newName: "IX_CategoryParent_ParentCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryParent",
                table: "CategoryParent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryParent_CategoryId",
                table: "CategoryParent",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CategoryParent_CategoryParentId",
                table: "Books",
                column: "CategoryParentId",
                principalTable: "CategoryParent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryParent_Category_CategoryId",
                table: "CategoryParent",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryParent_Category_ParentCategoryId",
                table: "CategoryParent",
                column: "ParentCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
