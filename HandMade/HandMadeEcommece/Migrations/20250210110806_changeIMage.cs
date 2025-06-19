using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandMadeEcommece.Migrations
{
    /// <inheritdoc />
    public partial class changeIMage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "ProductImageGalleries",
                type: "VARCHAR(255)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "ProductImageGalleries",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)");
        }
    }
}
