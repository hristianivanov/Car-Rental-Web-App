using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
                column: "ConcurrencyStamp",
                value: "edc14c95-a982-4e29-9824-83dffe2946be");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5f93b5d-71bc-4e0a-bf9b-a148d6486df7", "AQAAAAEAACcQAAAAEM+upaM2vPjrI1RN7cH8r1cgZWrFZn23cgcBsiFXBBwbH+AgYsHMMvJsY6jX2fVuQw==", "a537619b-68c8-4ee5-98b3-05b11adc6fae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d74de0f8-d579-4c4a-a547-6fe0c55c1e8d", "AQAAAAEAACcQAAAAEEFq/WXt0i/rbm8Sbo00uc3u27iQZI+i2IDfygfRiLmxE1eEGfp6HZZZwoMTgik2uA==", "8b10d8d3-95a9-486e-b37b-81fbe9f02857" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c5faac1-26eb-4369-bd4d-cc08a11ff999", "AQAAAAEAACcQAAAAEHGrOkJ8kNSyS7e4l4uEYt6td4LGOC2X1y4xyW9BDR76xi8BIiiHLsKqa2Nmo/lUew==", "2aa3ce55-c902-4704-98fa-9f5d90362eec" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a6e93473-1479-442f-a73a-96a5f4f94b2f"),
                column: "ImageUrl",
                value: "https://www.cnet.com/a/img/resize/607531bf946fb55b78d58ddf654b802133f3aeb3/hub/2021/11/10/e0e04238-ff8d-4e5a-9cd7-1dca34ec7843/2022-audi-rs-e-tron-gt-ogi-1.jpg?auto=webp&fit=crop&height=675&width=1200");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
                column: "ConcurrencyStamp",
                value: "d4997cb0-1b83-46b6-8da1-e90834a12a00");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0045b5f-9e4f-4b09-9e2b-d12ff4b071a8", "AQAAAAEAACcQAAAAEGxKAPHtyXAyQK2fgKaJMkDDWHAZf6XEwg3n8ZGDBNURNMvmaV8dwZ4Z9QPp+V740w==", "e1518365-9f61-47e8-88e9-cf7e8133f0b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4839640a-82d4-439e-9811-d600a8b95301", "AQAAAAEAACcQAAAAEPCYsKFm7hc2E5QlfXzPx4+NURHJqOM/lnle147WPve1DIpZQpVz8dYKwHAddYaU3w==", "127591e1-f1ad-4fe9-b55c-8dd9ca2db093" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "379ccc6a-541b-469c-99ac-2cba7d726f39", "AQAAAAEAACcQAAAAEExu4MKDaPscIklO9F5TPj1Kkw8WtjAYxuS67068QWfG1DmTtd3MtlI+5PkJQOexhA==", "80dd62bb-73db-406d-9643-9b5bf1b78051" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a6e93473-1479-442f-a73a-96a5f4f94b2f"),
                column: "ImageUrl",
                value: "https://www.carpixel.net/w/fb81ff032f94a62ab3734238828ca57c/audi-rs-e-tron-gt-car-wallpaper-103179.jpg");
        }
    }
}
