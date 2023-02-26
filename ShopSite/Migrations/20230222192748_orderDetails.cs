using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSite.Migrations
{
    public partial class orderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Products",
                newName: "OrderDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                newName: "IX_Products_OrderDetailsId");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDetailsId",
                table: "Orders",
                column: "OrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailsId",
                table: "Orders",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderDetails_OrderDetailsId",
                table: "Products",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderDetails_OrderDetailsId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderDetailsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderDetailsId",
                table: "Products",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OrderDetailsId",
                table: "Products",
                newName: "IX_Products_OrderId");

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
