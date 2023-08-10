using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class AddBlogEntityAndSeedTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsColors");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreaterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
                column: "ConcurrencyStamp",
                value: "92380a2e-8e1b-467e-837c-dbf525eff0a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ecdfd0a-5be5-434d-a3b3-cf7749ae21b0", "AQAAAAEAACcQAAAAEMvoHPmH+l/Ge4SMNDwNzwhsfifu4dLpNU1Bj3wkUfGpOgYyjhMGOcwSFMEeqd0Vdw==", "2210ff07-66f2-456a-b1aa-a58befe28250" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f9027cc-8849-4c49-9349-88cc5bde5671", "AQAAAAEAACcQAAAAELiE9OjMWUpgs1cEQ/uADQnzDNTx7oNo/eB0LR1bY2HHxJZIjHPk+cvp7CIDdF07Sg==", "1c2db3c9-8ca6-4c2b-8816-0e0982c0265a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f52e95e-bf1a-4dd0-8a02-a961299cd097", "AQAAAAEAACcQAAAAEOdCBeJUkiQH9qbvHxMlceLJ8181G/EyTKFH/02wh8ZW8MdKdYbzqMQ4SU8PH3WgMQ==", "3da02f0f-ab72-4de8-8166-aff612286b48" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedOn", "CreaterId", "Description", "ImageUrl", "Title" },
                values: new object[] { new Guid("7daff10e-1eb4-457f-88b1-2f21b1867f28"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a5edc49-7490-493f-2f01-08db8a416485"), "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.", "https://localhost:7263/images/blog/image_1.jpg", "Why Lead Generation Is Key For Business Growth" });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreaterId",
                table: "Blogs",
                column: "CreaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarsColors",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsColors", x => new { x.CarId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_CarsColors_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarsColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
                column: "ConcurrencyStamp",
                value: "4276eecb-fc70-4889-aa82-30cc9502e360");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "941454f4-f07e-4509-b844-98c6b0350adb", "AQAAAAEAACcQAAAAEF8tjaRmM/DferAUsCaUI/O5vdH579dlDH0hkb+rHdwtUhhIW/IFnEVaUVtv3yr1hw==", "24fe2d60-a830-4fd6-b9e6-db6d0607924e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d91be5d7-ff53-4a1a-b9f3-fbaff62bd5fa", "AQAAAAEAACcQAAAAEFZafQEsBSZ0LnzeodLbf4hJBR7wQZFo6U9zvPEWzCpINirRGnmYvodMBJHX3BAzJw==", "0d37242e-df41-4444-8259-33a328aaa885" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2643f7a3-0002-4ef7-a413-8a09260421ec", "AQAAAAEAACcQAAAAELOLFpB8DVizMFFEy4HaBEgRa4pUDbdTxNHcjHRL/sR/F0Ak+IQKT2U3rlvQSCVjcQ==", "24257ab6-7ac4-430a-adcc-0f438599bb7d" });

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

            migrationBuilder.CreateIndex(
                name: "IX_CarsColors_ColorId",
                table: "CarsColors",
                column: "ColorId");
        }
    }
}
