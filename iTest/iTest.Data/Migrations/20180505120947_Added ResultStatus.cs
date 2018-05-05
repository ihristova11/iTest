using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace iTest.Data.Migrations
{
    public partial class AddedResultStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserTest",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserTest",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ExecutedTime",
                table: "UserTest",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "ExecutionTime",
                table: "UserTest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserTest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserTest",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserTest",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserTest_Id",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "ExecutedTime",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "ExecutionTime",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserTest");

            migrationBuilder.DropColumn(
                name: "ResultStatus",
                table: "UserTest");
        }
    }
}
