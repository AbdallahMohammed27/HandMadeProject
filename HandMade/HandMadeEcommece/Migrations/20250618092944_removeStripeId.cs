using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandMadeEcommece.Migrations
{
    /// <inheritdoc />
    public partial class removeStripeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripeId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "StripeId",
                table: "DeliveryCompanies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StripeId",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripeId",
                table: "DeliveryCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
