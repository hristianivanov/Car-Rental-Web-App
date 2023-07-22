using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class remove_carIdRelationInImageData_temporary_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "ImageData",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_CarId",
                table: "ImageData",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Cars_CarId",
                table: "ImageData",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
