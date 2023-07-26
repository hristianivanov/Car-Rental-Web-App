using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class add_IsActive_columns_forSoftDeleteCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cars");
        }
    }
}
