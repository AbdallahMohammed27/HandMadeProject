using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandMadeEcommece.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Admins_AdminId",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Users_UserId",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Vendors_VendorId",
                table: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_AdminId",
                table: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_VendorId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "UserAddresses");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Users_UserId",
                table: "UserAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Users_UserId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "UserAddresses",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserAddresses",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserAddresses",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "UserAddresses",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "UserAddresses",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "UserAddresses",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "UserAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "UserAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AdminId",
                table: "UserAddresses",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_VendorId",
                table: "UserAddresses",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Admins_AdminId",
                table: "UserAddresses",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Users_UserId",
                table: "UserAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Vendors_VendorId",
                table: "UserAddresses",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id");
        }
    }
}
