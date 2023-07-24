using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class add_relationBetween_Car_ImageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "ImageData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_CarId",
                table: "ImageData",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Cars_CarId",
                table: "ImageData",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Cars_CarId",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_CarId",
                table: "ImageData");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "ImageData");
        }
    }
}
