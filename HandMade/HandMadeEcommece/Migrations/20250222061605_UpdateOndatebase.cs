using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandMadeEcommece.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOndatebase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ProductVariantItems_Product_Variant_Item_Id",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChildCategories_ChildCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ChildCategories");

            migrationBuilder.DropTable(
                name: "ProductVariantItems");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_Products_ChildCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ChildCategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Product_Variant_Item_Id",
                table: "CartItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_Product_Variant_Item_Id",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "Product_Variant_Item_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_Product_Variant_Item_Id");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChildCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductVariantItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsDefault = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Price = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariantItems_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChildCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ChildCategoryId",
                table: "Products",
                column: "ChildCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_SubCategoryId",
                table: "ChildCategories",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantItems_ProductVariantId",
                table: "ProductVariantItems",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ProductVariantItems_Product_Variant_Item_Id",
                table: "CartItems",
                column: "Product_Variant_Item_Id",
                principalTable: "ProductVariantItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChildCategories_ChildCategoryId",
                table: "Products",
                column: "ChildCategoryId",
                principalTable: "ChildCategories",
                principalColumn: "Id");
        }
    }
}
