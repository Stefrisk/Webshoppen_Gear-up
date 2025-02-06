using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshoppen_Gear_up.Migrations
{
    /// <inheritdoc />
    public partial class GearUp4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemQuantity",
                table: "ShoppingCartItem",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemQuantity",
                table: "ShoppingCartItem");
        }
    }
}
