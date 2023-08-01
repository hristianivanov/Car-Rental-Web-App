using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class seedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
                column: "ConcurrencyStamp",
                value: "3a4342f6-7de8-4bda-ab78-eb750d02a946");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f2c61a7-0cb9-4ec9-bbc1-c2fa55bbea22", "AQAAAAEAACcQAAAAECxf+427jdAdkf5jOylIckQ5qoLYemQ8wXdAIecvfdFW4+7wsUr4BL/7qoYYoUxLcA==", "811e87bb-041e-4077-9ba9-a597db9fdebf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0ab6e51-241a-41fb-8a35-27750355216a", "AQAAAAEAACcQAAAAEJ0t8j9xqTHZ/Y9zY/F2EzgiESqeM/rOQxNfAL2PikW3NaYgyBzcO7Aa6PrLPZwI9g==", "5b287c82-4e33-41b4-bff3-c2015ee0b383" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c77109f-0bc3-4794-8daa-ee92111df7b0", "AQAAAAEAACcQAAAAEGaJ6WKEZkuXtr8JGVZ+j6vdgTUUCQXe7iCBpzdfk205tdfmKO74uQogzLYhxxgYPg==", "eed4eea5-e744-430e-9304-f52a1f444f0d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
                column: "ConcurrencyStamp",
                value: "b29a9b2d-21cb-4f9e-a16c-8cebf17005f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cb5c97e-6501-46f1-8d27-84153982b49b", "AQAAAAEAACcQAAAAEJYL3iZU6RRWthexVblulP76y/bS7WZqUKq3zKooLOpIoqLtT/DZiw5juTmK+HJM3Q==", "fcd95f39-cfd3-48de-a9e6-a68118a8a59a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c467a198-0f38-431b-87ae-88513168d0e6", "AQAAAAEAACcQAAAAEN37nnuOekUiiCGUOwOrVDmVJVLvqj0VpDAbC6LaGF2m5AXCN9JG9xPmTwcc61gIvQ==", "0b5ac4a5-ac44-4365-8b1c-5ec01fe79799" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e586ec4-7102-4478-85a8-aabdc61bb4f8", "AQAAAAEAACcQAAAAEMfP8sh93FrA0xjz+pROo/cN4qrftDfkL5gG7TYgWD7q387Yzo/BnrIeBA2eoSjAvA==", "56831e77-06ed-443a-ad41-d6184adae945" });
        }
    }
}
