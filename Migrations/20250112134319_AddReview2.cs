using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlavorFusion.Migrations
{
    /// <inheritdoc />
    public partial class AddReview2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealPlanName",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealPlanName",
                table: "Review");
        }
    }
}
