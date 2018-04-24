using Microsoft.EntityFrameworkCore.Migrations;

namespace iTest.Data.Migrations
{
    public partial class IsCorrectandTestCollectionCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answers");
        }
    }
}
