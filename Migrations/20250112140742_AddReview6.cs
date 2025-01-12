using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlavorFusion.Migrations
{
    /// <inheritdoc />
    public partial class AddReview6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_MealPlan_MealPlanId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MealPlanId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "MealPlanName",
                table: "Review",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

          
   

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MealPlanName",
                table: "Review",
                column: "MealPlanName");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_MealPlan_MealPlanName",
                table: "Review",
                column: "MealPlanName",
                principalTable: "MealPlan",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_MealPlan_MealPlanName",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MealPlanName",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan");

            migrationBuilder.AlterColumn<string>(
                name: "MealPlanName",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<int>(
                name: "MealPlanId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

           

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MealPlanId",
                table: "Review",
                column: "MealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_MealPlan_MealPlanId",
                table: "Review",
                column: "MealPlanId",
                principalTable: "MealPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
