using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class addRenterIdColumnInCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RenterId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://pbs.twimg.com/media/FxTMcyQWwAMqIYk?format=jpg&name=large");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RenterId",
                table: "Cars",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_RenterId",
                table: "Cars",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_RenterId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RenterId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://yandex-images.clstorage.net/e9YZ9F383/e3049dM4PtiR/48AJY79fj0JYkNVSm-meE7lJbsJRL_EQAcWW2JV-OOBHJ2BVk10QiQJdiHxO8fKyuG6pwiz5nm8PCEny6b7Z1NK0zce-6ioWORWV0qu5v8ZteH8H8WogtCQFEogQHpilMcGSV8QLx09Qqt-L3yTiZ70KPQcpHH25vkgrpF9seWMh0RtA-05t8g9z5_Cqisylaqsv5nI4ELLGtvL_QCnPA6CCMNV0ChQekVq9KB4HYBRvKVmkCxx-qMiI2odeP4uhIhMocsleX3EcQMfjS_j-plgLfQZBq5Mg9jcTn2DZDTDC40FUxYp0vNGoXFsM53B1DykZ1wqN7QlKeBl37VwJcFLiCSLr7c5R3vP0ULlKX4R5-Y9HMXhAspdUYI9yW4_hUsARxzQIJq7xCe-4v-SCVX9omqQI_r7I2iraxu_c6XBRkHjB-Uz_833jhODaqW_HSMitx4PbcSF0lFLd8NhM80Gg8MaGihVNAHnP-4xEwCZua5j2ec_8KsrI2qUtjJiBEFDI4qld3IO-slQiyvhuxZkKf8fxyuGRNuSQjxB7jBJiYfCW5OqljSFY7bmP5XDEvnnpJJrsDPsKeTnl3944U3HiaVCrf85SzABEcznbTuf6mH32gXly8BZmkX8wqH7BouHiZaWI9dzBqH_anRXgNp0622QbHExauspot9wMu-PCckjyqexdYu1QJgILKe9E2jh9FzLZQIC0dtKPY4ksIkCSQiVUOyVcYunsSx6mUYXvSRs1Kq8_Gis5WqZcTjhTQeIqAjkuHmI9QkYiashPVmk6PhZT-kFTBMXi3KGpnyGQg3L1VzrE_mJrjygs9jGmjdiYpriuTCr4edjW7o4a0OLQWmBbzi_R_IHWUfqp7hQ7yU6HgTox8Ce1gIyDe76Q00MSJPZalN7CGv5L7KQAlI4q2XaanoxoKnopl6yf-zMwkUhwq-5MU36iF9Cq6P2nmJtfRnH7EAL1t0Lfc");
        }
    }
}
