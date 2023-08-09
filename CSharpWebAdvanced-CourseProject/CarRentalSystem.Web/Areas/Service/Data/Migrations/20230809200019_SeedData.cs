using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Web.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImageUrl", "Text", "Title" },
                values: new object[] { 1, "https://luxurysupercarsdubai.com/wp-content/uploads/2023/02/proving.webp", "Luxury Supercar Rentals Dubai ​prides itself on being the leading prestige and performance car hire company in the industry. At​ Luxury Supercar Rentals​, we give you the opportunity to get your pulse racing, make a lasting impression at your next corporate or social event, or simply drive the car of your dreams. ​ We don’t just offer you a luxury car model; we also offer you a luxury car hire experience. Our staff are fully trained to ensure your luxury car comes to you spotless and well-serviced so you can be confident that the vehicle you’re driving is safe, performing to its highest standard, and of prestige quality.Our luxury car rental service is tailored to suit your lifestyle whether you want comfort, speed, economy or a combination of all three. We will source the best vehicle for you. With a fleet of over 50 different prestige, luxury and supercars, we offer an unrivalled selection, including exclusive models from ​Ferrari​, Lamborghini, ​Bentley​, Rolls Royce, Maserati, Mercedes​, BMW, ​Porsche​ and ​Audi​. At LSR we pride ourselves on client satisfaction, which is why we offer a superb selection of Luxury cars at fantastic value for money prices. Our service includes exclusive benefits such as Free Pick up & drop off anywhere in Dubai, discounts on ​long term rental hire​ and insurance included across our entire fleet.", "Self Drive Car Rental" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ImageUrl", "Text", "Title" },
                values: new object[] { 2, "https://luxurysupercarsdubai.com/wp-content/uploads/2023/02/long-term.webp", "For long-term travel plans and replacement car needs, an affordable monthly rental from Luxury Supercar Rentals can be the ideal solution. The longer you choose to rent with Luxury Supercar Rentals, the cheaper the price becomes, meaning you can drive that premium rental car you’ve always wanted for a price that doesn’t exceed the budget.", "Long Term Rental" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
