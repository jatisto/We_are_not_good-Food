using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeAreNotGoodFoodVerCore2.Migrations
{
    public partial class LiseShopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "ShoppingCartItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_RestaurantId",
                table: "ShoppingCartItem",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Restaurants_RestaurantId",
                table: "ShoppingCartItem",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Restaurants_RestaurantId",
                table: "ShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_RestaurantId",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "ShoppingCartItem");
        }
    }
}
