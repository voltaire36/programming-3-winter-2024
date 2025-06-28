using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        IdProduct = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.IdProduct);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Shoppers",
            //    columns: table => new
            //    {
            //        IdShopper = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StateProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Shoppers", x => x.IdShopper);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Baskets",
            //    columns: table => new
            //    {
            //        IdBasket = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdShopper = table.Column<int>(type: "int", nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
            //        OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Baskets", x => x.IdBasket);
            //        table.ForeignKey(
            //            name: "FK_Baskets_Shoppers_IdShopper",
            //            column: x => x.IdShopper,
            //            principalTable: "Shoppers",
            //            principalColumn: "IdShopper",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BasketItems",
            //    columns: table => new
            //    {
            //        IdBasketItem = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdProduct = table.Column<int>(type: "int", nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        IdBasket = table.Column<int>(type: "int", nullable: false),
            //        BasketIdBasket = table.Column<int>(type: "int", nullable: false),
            //        ProductIdProduct = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BasketItems", x => x.IdBasketItem);
            //        table.ForeignKey(
            //            name: "FK_BasketItems_Baskets_BasketIdBasket",
            //            column: x => x.BasketIdBasket,
            //            principalTable: "Baskets",
            //            principalColumn: "IdBasket",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BasketItems_Products_ProductIdProduct",
            //            column: x => x.ProductIdProduct,
            //            principalTable: "Products",
            //            principalColumn: "IdProduct",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_BasketItems_BasketIdBasket",
            //    table: "BasketItems",
            //    column: "BasketIdBasket");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BasketItems_ProductIdProduct",
            //    table: "BasketItems",
            //    column: "ProductIdProduct");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Baskets_IdShopper",
            //    table: "Baskets",
            //    column: "IdShopper");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shoppers");
        }
    }
}
