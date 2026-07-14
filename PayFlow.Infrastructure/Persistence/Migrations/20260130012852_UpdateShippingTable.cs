using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayflowApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShippingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Shipping");

            migrationBuilder.DropColumn(
                name: "Freight",
                table: "Shipping");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Shipping");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shipping",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shipping",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shipping");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shipping");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime",
                table: "Shipping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Freight",
                table: "Shipping",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Shipping",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
