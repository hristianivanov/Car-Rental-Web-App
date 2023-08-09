using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Web.Migrations
{
    public partial class SeedAnotherData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImageUrl", "Text", "Title" },
                values: new object[] { 3, "https://luxurysupercarsdubai.com/wp-content/uploads/2023/02/weddings.webp", "We provide luxury wedding cars for your special day all year round and ensure that you make the grandest entrance to one of the most memorable days of your life. Here at Luxury Supercars Dubai we have an extensive fleet of luxury wedding cars available, ranging from Rolls Royce and Lamborghini to Bentley and Mercedes. So no matter your preference we have the perfect wedding car for you.Have a look at our collection of luxury cars and choose the one that suits your needs and requirements. If you are confused and not sure which car you should hire for your special day, do not worry as our expert car hire team are here to guide you every step of the way.They will ensure that the vehicle compliments the style and theme of the occasion perfectly.Our luxury collection consists of a wide range of the most prestigious luxury vehicles in the world. From Rolls Royce and Lamborghini to Ferrari and Bentley. We continue to add to our collection each year and strive to have the best available.", "Weddings & Special Events" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImageUrl", "Text", "Title" },
                values: new object[] { 4, "https://luxurysupercarsdubai.com/wp-content/uploads/2023/02/gift.webp", "There’s no better gift than a fancy ride in Dubai’s streets. Allow your loved ones to feel special while riding in Dubai’s elite car collection from Luxury Supercar Rentals.Our offices provide gift cards and vouchers for all your occasions.Do not hesitate to get more information about our gift vouchers program.", "Gift Vouchers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
