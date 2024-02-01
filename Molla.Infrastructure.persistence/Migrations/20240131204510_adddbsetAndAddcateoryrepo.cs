using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molla.Infrastructure.persistence.Migrations
{
    /// <inheritdoc />
    public partial class adddbsetAndAddcateoryrepo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_CategoryGroups_CategoryGroupId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Products_ProductId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StockByColorSize_Color_ColorId",
                table: "StockByColorSize");

            migrationBuilder.DropForeignKey(
                name: "FK_StockByColorSize_Size_SizeId",
                table: "StockByColorSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gallery",
                table: "Gallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "Gallery",
                newName: "Galleries");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Gallery_ProductId",
                table: "Galleries",
                newName: "IX_Galleries_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_CategoryGroupId",
                table: "Categories",
                newName: "IX_Categories_CategoryGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryGroups_CategoryGroupId",
                table: "Categories",
                column: "CategoryGroupId",
                principalTable: "CategoryGroups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Products_ProductId",
                table: "Galleries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockByColorSize_Colors_ColorId",
                table: "StockByColorSize",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockByColorSize_Sizes_SizeId",
                table: "StockByColorSize",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryGroups_CategoryGroupId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Products_ProductId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StockByColorSize_Colors_ColorId",
                table: "StockByColorSize");

            migrationBuilder.DropForeignKey(
                name: "FK_StockByColorSize_Sizes_SizeId",
                table: "StockByColorSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "Galleries",
                newName: "Gallery");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Galleries_ProductId",
                table: "Gallery",
                newName: "IX_Gallery_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoryGroupId",
                table: "Category",
                newName: "IX_Category_CategoryGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gallery",
                table: "Gallery",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_CategoryGroups_CategoryGroupId",
                table: "Category",
                column: "CategoryGroupId",
                principalTable: "CategoryGroups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Products_ProductId",
                table: "Gallery",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockByColorSize_Color_ColorId",
                table: "StockByColorSize",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockByColorSize_Size_SizeId",
                table: "StockByColorSize",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
