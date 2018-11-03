using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeAreNotGoodFoodVerCore2.Data.Migrations
{
    public partial class AddUserIdDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdDish",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_UserId",
                table: "Dishes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_AspNetUsers_UserId",
                table: "Dishes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_AspNetUsers_UserId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_UserId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "UserIdDish",
                table: "Dishes");
        }
    }
}
