using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlavorFusion.Migrations
{
    /// <inheritdoc />
    public partial class AddMealPlan7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Breakfast",
                table: "MealPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dinner",
                table: "MealPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lunch",
                table: "MealPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "MealPlan");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "MealPlan");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "MealPlan");
        }
    }
}
