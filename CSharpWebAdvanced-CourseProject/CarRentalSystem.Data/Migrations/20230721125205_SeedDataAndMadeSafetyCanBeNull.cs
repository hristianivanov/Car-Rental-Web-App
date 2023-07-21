using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class SeedDataAndMadeSafetyCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Safety",
                table: "Cars",
                type: "tinyint",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 5);

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/T9T9.png", "Ibis White" },
                    { 2, "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/6Y6Y.png", "Daytona Grey Pearl effect" },
                    { 3, "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/9W9W.png", "Ascari Blue Metallic" },
                    { 4, "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/Y1Y1.png", "Tango Red Metallic" },
                    { 5, "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/V0V0.png", "Tactics Green Metallic" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name", "NewInnovation" },
                values: new object[,]
                {
                    { 1, "Acura", "IntelliCruise" },
                    { 2, "Alfa Romeo", "Active Aero Splitter" },
                    { 3, "Audi", "Virtual Cockpit Plus" },
                    { 4, "BMW", "Gesture Control 2.0" },
                    { 5, "Bentley", "Self-Leveling Air Suspension" },
                    { 6, "Ferrari", "Side Slip Control" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Acceleration", "BodyType", "Consumption", "FuelAmount", "HorsePower", "MakeId", "Mileage", "Model", "PassengerSeats", "Range", "Safety", "TopSpeed", "Transmission", "Year" },
                values: new object[] { 1, 2.8999999999999999, 3, 20.199999999999999, (byte)0, 637, 3, 5000L, "RS e-tron GT", (byte)5, 298, (byte)5, 155, 1, 2021 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Acceleration", "BodyType", "Consumption", "FuelAmount", "HorsePower", "MakeId", "Mileage", "Model", "PassengerSeats", "Range", "Safety", "TopSpeed", "Transmission", "Year" },
                values: new object[] { 2, 6.2000000000000002, 4, 6.2000000000000002, (byte)0, 261, 3, 450000L, "A5 SB basic", (byte)5, 520, (byte)4, 126, 1, 2013 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Acceleration", "BodyType", "Consumption", "FuelAmount", "HorsePower", "MakeId", "Mileage", "Model", "PassengerSeats", "Range", "Safety", "TopSpeed", "Transmission", "Year" },
                values: new object[] { 3, 5.5, 1, 7.0999999999999996, (byte)0, 340, 4, 53000L, "X6 40d", (byte)5, 704, (byte)4, 147, 1, 2012 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<byte>(
                name: "Safety",
                table: "Cars",
                type: "tinyint",
                maxLength: 5,
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 5,
                oldNullable: true);
        }
    }
}
