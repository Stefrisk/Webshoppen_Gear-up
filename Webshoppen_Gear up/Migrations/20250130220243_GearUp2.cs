using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshoppen_Gear_up.Migrations
{
    /// <inheritdoc />
    public partial class GearUp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ShoppingCart_Shopping_CartID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Shopping_CartID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Shopping_CartID",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "ShoppingCart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shopping_CartID = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCart_Shopping_CartID",
                        column: x => x.Shopping_CartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "Shopping_CartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ItemID",
                table: "ShoppingCart",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ItemId",
                table: "ShoppingCartItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_Shopping_CartID",
                table: "ShoppingCartItem",
                column: "Shopping_CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Items_ItemID",
                table: "ShoppingCart",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Items_ItemID",
                table: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_ItemID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<int>(
                name: "Shopping_CartID",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Shopping_CartID",
                table: "Items",
                column: "Shopping_CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ShoppingCart_Shopping_CartID",
                table: "Items",
                column: "Shopping_CartID",
                principalTable: "ShoppingCart",
                principalColumn: "Shopping_CartID");
        }
    }
}
