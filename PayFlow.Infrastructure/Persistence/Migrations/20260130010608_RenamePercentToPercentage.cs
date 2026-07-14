using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayflowApi.Migrations
{
    /// <inheritdoc />
    public partial class RenamePercentToPercentage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "Discount");

            migrationBuilder.DropColumn(
                name: "TotalWithDiscount",
                table: "Discount");

            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "Discount",
                newName: "Percentage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Percentage",
                table: "Discount",
                newName: "DiscountPercentage");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                table: "Discount",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalWithDiscount",
                table: "Discount",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
