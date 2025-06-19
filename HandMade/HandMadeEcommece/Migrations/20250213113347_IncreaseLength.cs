using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandMadeEcommece.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "checkUserNameAndEmails",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "checkUserNameAndEmails",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "checkUserNameAndEmails",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "checkUserNameAndEmails",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);
        }
    }
}
