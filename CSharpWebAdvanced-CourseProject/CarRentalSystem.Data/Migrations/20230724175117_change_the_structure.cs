using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class change_the_structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageData");

            migrationBuilder.AddColumn<decimal>(
                name: "Deposit",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "EngineType",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDay",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EngineType", "ImageUrl", "PricePerDay" },
                values: new object[] { 2, "https://www.carpixel.net/w/fb81ff032f94a62ab3734238828ca57c/audi-rs-e-tron-gt-car-wallpaper-103179.jpg", 420m });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EngineType", "ImageUrl", "PricePerDay" },
                values: new object[] { 1, "https://imagizer.imageshack.com/a/img29/5097/gu89.jpg", 329m });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EngineType", "ImageUrl", "PricePerDay" },
                values: new object[] { 1, "https://avatars.mds.yandex.net/get-autoru-vos/5234682/06057d0f4b94a888f5c8112546a31a43/1200x900", 412m });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Acceleration", "BodyType", "Consumption", "EngineType", "FuelAmount", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "PassengerSeats", "PricePerDay", "Range", "Safety", "TopSpeed", "Transmission", "Year" },
                values: new object[,]
                {
                    { 4, 3.6000000000000001, 18, 18.300000000000001, 1, (byte)0, 483, "https://photos.carspecs.us/d389399428d2ba5d065c5b6f59aaf3771a41ca4b-2000.jpg", 6, 230532L, "F430", (byte)2, 620m, 323, (byte)3, 196, 1, 2004 },
                    { 5, 5.4000000000000004, 0, 28.5, 1, (byte)0, 280, "https://yandex-images.clstorage.net/e9YZ9F383/e3049dM4PtiR/48AJY79fj0JYkNVSm-meE7lJbsJRL_EQAcWW2JV-OOBHJ2BVk10QiQJdiHxO8fKyuG6pwiz5nm8PCEny6b7Z1NK0zce-6ioWORWV0qu5v8ZteH8H8WogtCQFEogQHpilMcGSV8QLx09Qqt-L3yTiZ70KPQcpHH25vkgrpF9seWMh0RtA-05t8g9z5_Cqisylaqsv5nI4ELLGtvL_QCnPA6CCMNV0ChQekVq9KB4HYBRvKVmkCxx-qMiI2odeP4uhIhMocsleX3EcQMfjS_j-plgLfQZBq5Mg9jcTn2DZDTDC40FUxYp0vNGoXFsM53B1DykZ1wqN7QlKeBl37VwJcFLiCSLr7c5R3vP0ULlKX4R5-Y9HMXhAspdUYI9yW4_hUsARxzQIJq7xCe-4v-SCVX9omqQI_r7I2iraxu_c6XBRkHjB-Uz_833jhODaqW_HSMitx4PbcSF0lFLd8NhM80Gg8MaGihVNAHnP-4xEwCZua5j2ec_8KsrI2qUtjJiBEFDI4qld3IO-slQiyvhuxZkKf8fxyuGRNuSQjxB7jBJiYfCW5OqljSFY7bmP5XDEvnnpJJrsDPsKeTnl3944U3HiaVCrf85SzABEcznbTuf6mH32gXly8BZmkX8wqH7BouHiZaWI9dzBqH_anRXgNp0622QbHExauspot9wMu-PCckjyqexdYu1QJgILKe9E2jh9FzLZQIC0dtKPY4ksIkCSQiVUOyVcYunsSx6mUYXvSRs1Kq8_Gis5WqZcTjhTQeIqAjkuHmI9QkYiashPVmk6PhZT-kFTBMXi3KGpnyGQg3L1VzrE_mJrjygs9jGmjdiYpriuTCr4edjW7o4a0OLQWmBbzi_R_IHWUfqp7hQ7yU6HgTox8Ce1gIyDe76Q00MSJPZalN7CGv5L7KQAlI4q2XaanoxoKnopl6yf-zMwkUhwq-5MU36iF9Cq6P2nmJtfRnH7EAL1t0Lfc", 2, 623142L, "Giulia", (byte)5, 205m, 464, (byte)4, 191, 0, 2018 },
                    { 6, 4.5, 0, 22.699999999999999, 1, (byte)0, 500, "https://sun9-46.userapi.com/impg/jGF9KYUrkOJ81ExMSYNNE4L7fh4GD5Ryoic6zA/Iy6iwscdEg0.jpg?size=1920x1280&quality=95&sign=637909ae3d1112f8306502533c876ba3&c_uniq_tag=3K2cQHcDOmacj7mo5PNx7wX_XCN3EOQggqEfBc4h6iI&type=album", 4, 575531L, "e60 M5", (byte)5, 130m, 293, (byte)3, 190, 1, 2005 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "EngineType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Cars");

            migrationBuilder.CreateTable(
                name: "ImageData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    FullscreenContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    OriginalContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageData_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_CarId",
                table: "ImageData",
                column: "CarId");
        }
    }
}
