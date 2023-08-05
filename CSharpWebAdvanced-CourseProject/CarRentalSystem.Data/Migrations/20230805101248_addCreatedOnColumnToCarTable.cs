using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class addCreatedOnColumnToCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cars");

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
        }
    }
}
