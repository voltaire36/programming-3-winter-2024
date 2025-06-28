using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLibrary.Migrations
{
    public partial class UpdateToMatchSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketIdBasket",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductIdProduct",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketIdBasket",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_ProductIdProduct",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "BasketIdBasket",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "ProductIdProduct",
                table: "BasketItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<short>(
                name: "IdProduct",
                table: "Products",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "Baskets",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<byte>(
                name: "Quantity",
                table: "Baskets",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Quantity",
                table: "BasketItems",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "IdProduct",
                table: "BasketItems",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_IdBasket",
                table: "BasketItems",
                column: "IdBasket");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_IdProduct",
                table: "BasketItems",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_IdBasket",
                table: "BasketItems",
                column: "IdBasket",
                principalTable: "Baskets",
                principalColumn: "IdBasket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_IdProduct",
                table: "BasketItems",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_IdBasket",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_IdProduct",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_IdBasket",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_IdProduct",
                table: "BasketItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<int>(
                name: "IdProduct",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "Baskets",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Baskets",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "BasketItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "IdProduct",
                table: "BasketItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "BasketIdBasket",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductIdProduct",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketIdBasket",
                table: "BasketItems",
                column: "BasketIdBasket");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductIdProduct",
                table: "BasketItems",
                column: "ProductIdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketIdBasket",
                table: "BasketItems",
                column: "BasketIdBasket",
                principalTable: "Baskets",
                principalColumn: "IdBasket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductIdProduct",
                table: "BasketItems",
                column: "ProductIdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
