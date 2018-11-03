using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeAreNotGoodFoodVerCore2.Data.Migrations
{
    public partial class renameDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserIdDish",
                table: "Dishes",
                newName: "UserDishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserDishId",
                table: "Dishes",
                newName: "UserIdDish");
        }
    }
}
