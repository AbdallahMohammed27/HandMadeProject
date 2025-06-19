using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandMadeEcommece.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WishList",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_UserId",
                table: "WishList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishList",
                table: "WishList",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ProductId",
                table: "WishList",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WishList",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_ProductId",
                table: "WishList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishList",
                table: "WishList",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");
        }
    }
}
