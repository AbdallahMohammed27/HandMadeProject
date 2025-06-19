using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandMadeEcommece.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAllImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Vendors",
                type: "VARCHAR(255)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Users",
                type: "VARCHAR(255)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThumbImage",
                table: "Products",
                type: "VARCHAR(255)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "DeliveryCompanies",
                type: "VARCHAR(255)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "VARCHAR(255)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Brands",
                type: "VARCHAR(255)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Admins",
                type: "VARCHAR(255)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Vendors",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ThumbImage",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Logo",
                table: "DeliveryCompanies",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Icon",
                table: "Categories",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Logo",
                table: "Brands",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Admins",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldNullable: true);
        }
    }
}
