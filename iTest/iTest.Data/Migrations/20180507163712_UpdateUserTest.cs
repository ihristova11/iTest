using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iTest.Data.Migrations
{
    public partial class UpdateUserTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserTest_Id",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "ResultStatus",
                table: "UserTest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserTest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResultStatus",
                table: "UserTest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserTest_Id",
                table: "UserTest",
                column: "Id");
        }
    }
}
