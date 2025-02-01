using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshoppen_Gear_up.Migrations
{
    /// <inheritdoc />
    public partial class GearUp1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "ShoppingCart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartID",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerID",
                table: "ShoppingCart",
                column: "CustomerID",
                unique: true,
                filter: "[CustomerID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Customers_CustomerID",
                table: "ShoppingCart",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Customers_CustomerID",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_CustomerID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "ShoppingCartID",
                table: "Customers");
        }
    }
}
