using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    public partial class SeedMoreCarsAndMakes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("058de5cf-340b-4811-9866-3d5b621d5635"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("34ce1d26-6410-40cc-867c-9238f3ad4bf0"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("5374c53d-0bc2-4025-ab52-bc6d7f7897c9"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("d3f3cc89-7480-423f-959d-4ed070fceb18"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "081599a5-0418-4b57-a6a9-eb9f8cd9a0b9", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d982804a-0ab4-431a-bd80-d47a63df7c9d", "AQAAAAEAACcQAAAAEPsH/6xY2LIJzhTXOmf3Kv+DOMxdMB2syuFzYdx+rm6yADwKt2+Wu3W2jZMgIf8lgw==", "5f9ba857-8e15-42e9-8ca6-4e3b2e4e7327" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "792af345-c865-46e9-a5c0-5ff846218ec5", "AQAAAAEAACcQAAAAEPp1RVOhw8h/kl0N763u944tZ0BfbBFZFUtQPwxldAxB73JW+fYpPK/TQmX/nEaePg==", "6a8ab44e-1559-462c-93df-cc6b25a19bde" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a85a9f75-6ce6-48d2-9867-d265b79bb337", "AQAAAAEAACcQAAAAEDnnbqLmxF43vlMTeU0kkIAfGZLxMNILUoNyvUPHKMAiV80CJ0HFwAh/AcwXkDLs8Q==", "0b021127-e3c9-4c28-bceb-9d906dc91f0e" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedOn", "CreaterId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("1a563903-be4d-4865-8184-c8f3559b6549"), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f06d4765-779a-4766-eb64-08db8a42133c"), "Are you tired of the ordinary? Do you crave thrilling adventures that push your boundaries and ignite your sense of wanderlust? Look no further! Renting a G Wagon for off-road excursions is the perfect way to unleash your inner adventurer and embark on unforgettable journeys into the great outdoors. With its rugged design, exceptional performance, and luxurious features, the G Wagon is the ultimate companion for those seeking thrilling off-road experiences.This blog will explore why you should rent G Wagon for off-road excursions and what makes it an absolute game-changer. So fasten your seat belts and get ready for an adrenaline-pumping ride!Unparalleled Off-Road Capability. When it comes to conquering challenging terrains, the G Wagon is in a league of its own. With its robust build, advanced four-wheel-drive system, and high ground clearance, this formidable machine is built to handle any off-road obstacle that comes its way. So whether you are navigating steep inclines, crossing rocky landscapes, or fording through water bodies, the G Wagon’s off-road capability ensures that you stay in control and easily reach your destination.", "https://i0.wp.com/www.car-revs-daily.com/wp-content/uploads/2014/10/2015-BMW-X6-M-27.jpg?fit=2625%2C1281&ssl=1", "Unleash Your Inner Adventurer: Rent a G Wagon for Off-Road Excursions" },
                    { new Guid("8926f339-cb6f-47a5-b9aa-d63645d89b9b"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a5edc49-7490-493f-2f01-08db8a416485"), "Dubai is renowned for its opulence and luxury, and one of the ultimate symbols of extravagance is cruising through the city in a Bugatti. Known for its sleek design, unmatched power, and jaw-dropping speed, the Bugatti is the epitome of automotive excellence. If you’re considering a Bugatti rental Dubai for the first time, here’s what you can expect from this unforgettable experience.Unparalleled PerformanceWhen you opt for a Bugatti hire, you’re not just renting a car; you’re gaining access to a supercar that is in a league of its own. The Bugatti’s engine roars to life, producing an adrenaline-pumping symphony of power. As you press the accelerator, you’ll feel a surge of acceleration that pins you to the seat. With its impressive horsepower and exceptional handling, the Bugatti delivers a driving experience like no other. Be prepared to be amazed by its speed, agility, and the flawless way it hugs the road.Exquisite Design and CraftsmanshipBugatti cars are known for their striking beauty and meticulous attention to detail. From the moment you set eyes on a Bugatti, you’ll be captivated by its elegant curves and aerodynamic profile. The interior is equally breathtaking, with luxurious materials, handcrafted finishes, and state-of-the-art technology. Every inch of a Bugatti exudes sophistication and refinement, making it an absolute pleasure to drive and admire.", "https://localhost:7263/images/blog/image_1.jpg", "What to Expect When You Rent a Bugatti in Dubai: A Guide for First-Timers" },
                    { new Guid("9b86277f-184e-4e74-9185-3505b683fb82"), new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a5edc49-7490-493f-2f01-08db8a416485"), "If you have ever dreamed of feeling the luxurious thrill of having Italian engineering at your fingertips, then renting a Lamborghini Aventador could be the perfect way to live out that dream. This ultimate driving experience comes with everything from an innovative design and cutting-edge powertrain, to excellent handling capabilities and advanced safety features.But beyond some fantastic performance numbers, when you rent a Lamborghini Aventador Dubai, you enjoy access to exclusive amenities and services that give you an unforgettable drive every time. So if you are looking for something extraordinary behind the wheel, read on as we explore why renting a Lamborghini Aventador is worth every penny!1- Turn Heads Everywhere You Go:As one of the most iconic cars on the market, you can be sure that the Lamborghini Aventador will not fail to turn heads when you drive it. With its sharp lines and bold design, this car is an instant showstopper – giving you a chance to make a statement wherever you go.2- Feel Unmatched Power:When you rent a Lamborghini Aventador, you do not just get an impressive look, but also exceptional performance. Powered by a V12 engine with up to 740 horsepower, this car can take your driving experience to another level as it races from 0-60 in just 2.9 seconds!3- Enjoy Advanced Technology:The Lamborghini Aventador doesn’t just look great, but it also comes with several advanced technologies to enhance your drive. From a 12.3-inch TFT digital instrument cluster and an 8.4-inch touchscreen infotainment system to adaptive suspension and active aerodynamics – this car has it all!4- Receive Personalized Service:When you rent a Lamborghini Aventador, you get access to the exclusive services of the dealership. From 24/7 roadside assistance and custom detailing packages to personalized concierge services – they have got everything covered for you so that you can enjoy a hassle-free experience every time!5- Experience Luxury Like Never Before:Renting a Lamborghini Aventador allows you to experience true luxury like never before. From plush leather seating and high-end audio systems to aerodynamic body styling and other premium features – it is the perfect car for those who want an extraordinary driving experience.6- Unbeatable Price:Of course, the best part of all is that you can hire a Lamborghini Aventador in Dubai for an unbeatable price. Whether you choose to rent hourly or long-term, you will get access to exclusive offers and competitive rates – making it well worth every penny!", "https://www.digitaltrends.com/wp-content/uploads/2020/01/lamborghini_aventador_svj_roadster_1.jpg?fit=1500%2C1000&p=1", "Why Renting a Lamborghini Aventador is Worth Every Penny" },
                    { new Guid("db99ac7d-3eff-4302-a1ee-604526aaf16c"), new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f06d4765-779a-4766-eb64-08db8a42133c"), "Embarking on a road trip is an exhilarating experience filled with freedom, adventure, and the open road stretching ahead. Proper preparation is vital to ensuring a smooth and enjoyable journey if you are planning a road trip and opting for a car rental. In this blog, we will guide you through essential steps and tips to follow when you hire a luxury car in Dubai. From choosing the right vehicle to planning your route and packing smartly, let’s dive into the details and make your road trip an unforgettable experience.Choose the Right Rental VehicleThe first step in preparing for your car rental adventure is selecting the ideal vehicle for your needs. Consider factors such as the number of passengers, luggage space requirements, and the terrain you will encounter. Whether you opt for a spacious SUV for a family trip, a fuel-efficient sedan for a solo adventure, or a luxurious convertible for a stylish getaway, choose a vehicle that suits your preferences and enhances your overall road trip experience.Research and Compare Rental Companies. With numerous car rental companies available, conducting thorough research and comparing their offerings is essential. Look for reputable companies that provide reliable vehicles, transparent pricing, and excellent customer service. Read reviews, check for hidden fees, and compare rental rates to ensure you get the best value. Additionally, consider rental policies, such as mileage limitations and insurance coverage, to make an informed decision.", "https://media.autoexpress.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1562255176/autoexpress/porsche-911-c4-cabriolet-1-front-cornering.jpg", "Road Trip Ready: Preparing for Your Car Rental Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name", "NewInnovation" },
                values: new object[,]
                {
                    { 7, "Chevrolet", "myChevrolet Mobile App" },
                    { 8, "Ford", "Ford Co-Pilot360" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Acceleration", "BodyType", "Consumption", "EngineType", "FuelAmount", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "PassengerSeats", "PricePerDay", "Range", "RenterId", "Safety", "TopSpeed", "Transmission", "Year" },
                values: new object[] { new Guid("3c5788d6-865f-456c-b23c-39c28cdfe131"), 3.2000000000000002, 3, 29.32, 1, (byte)0, 428, "https://cdn.motor1.com/images/mgl/vxoL0b/s1/2022-ford-gt-64-heritage-edition-04.jpg", 8, 22931L, "GT", (byte)2, 201.59m, 302, null, (byte)4, 201, 1, 2014 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Acceleration", "BodyType", "Consumption", "EngineType", "FuelAmount", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "PassengerSeats", "PricePerDay", "Range", "RenterId", "Safety", "TopSpeed", "Transmission", "Year" },
                values: new object[] { new Guid("65ee10ee-99dc-4265-b93a-ce5c5e954d63"), 4.0, 3, 26.32, 1, (byte)0, 638, "https://img.remediosdigitales.com/c661b4/2018-chevrolet-camaro-zl1-1le-001p/1366_2000.jpg", 7, 10531L, "Camaro", (byte)2, 530.99m, 503, null, (byte)5, 210, 0, 2011 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("1a563903-be4d-4865-8184-c8f3559b6549"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("8926f339-cb6f-47a5-b9aa-d63645d89b9b"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("9b86277f-184e-4e74-9185-3505b683fb82"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("db99ac7d-3eff-4302-a1ee-604526aaf16c"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("3c5788d6-865f-456c-b23c-39c28cdfe131"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("65ee10ee-99dc-4265-b93a-ce5c5e954d63"));

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eba1e76b-c6a4-4d55-96a1-af76b359c115"),
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "683aeb79-3197-4047-b57f-f2e28aab64c0", "Master Administrator" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a5edc49-7490-493f-2f01-08db8a416485"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90b5d463-ffab-471e-97ae-e450c39bf912", "AQAAAAEAACcQAAAAEF19IdFUhisCxL6h5Zfu0PIh6HxiHIHGgPHS+5E+vWLIcZjG6bnNpiuD5vg4kojTMg==", "2a1eea56-b801-42f6-8490-e2490517d0d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f06d4765-779a-4766-eb64-08db8a42133c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d630801-3c70-4ae1-be62-85b53e2974a5", "AQAAAAEAACcQAAAAEOUWjYLgg9V2lF0qeXxLHS4YybwBDP1VkPkhBwmLsBUOLttCj89dlD8d5CG2Has4rQ==", "6d80405a-2b6a-4043-ad21-dc86ec6b2985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f2525385-0162-4b42-8fa5-08db8a43496a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab422c9a-439e-4f36-be46-94dd8061b438", "AQAAAAEAACcQAAAAEHb3jEFNQ0bQtRayWoXSKlU/e7Ks80Ak3OBBjzjAX5FEnbcrba08LAovvw5Ex4Z0OQ==", "1a03a17d-79b9-4d6f-b6fd-b04b59f74a49" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedOn", "CreaterId", "Description", "ImageUrl", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("058de5cf-340b-4811-9866-3d5b621d5635"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a5edc49-7490-493f-2f01-08db8a416485"), "Dubai is renowned for its opulence and luxury, and one of the ultimate symbols of extravagance is cruising through the city in a Bugatti. Known for its sleek design, unmatched power, and jaw-dropping speed, the Bugatti is the epitome of automotive excellence. If you’re considering a Bugatti rental Dubai for the first time, here’s what you can expect from this unforgettable experience.Unparalleled PerformanceWhen you opt for a Bugatti hire, you’re not just renting a car; you’re gaining access to a supercar that is in a league of its own. The Bugatti’s engine roars to life, producing an adrenaline-pumping symphony of power. As you press the accelerator, you’ll feel a surge of acceleration that pins you to the seat. With its impressive horsepower and exceptional handling, the Bugatti delivers a driving experience like no other. Be prepared to be amazed by its speed, agility, and the flawless way it hugs the road.Exquisite Design and CraftsmanshipBugatti cars are known for their striking beauty and meticulous attention to detail. From the moment you set eyes on a Bugatti, you’ll be captivated by its elegant curves and aerodynamic profile. The interior is equally breathtaking, with luxurious materials, handcrafted finishes, and state-of-the-art technology. Every inch of a Bugatti exudes sophistication and refinement, making it an absolute pleasure to drive and admire.", "https://localhost:7263/images/blog/image_1.jpg", false, "What to Expect When You Rent a Bugatti in Dubai: A Guide for First-Timers" },
                    { new Guid("34ce1d26-6410-40cc-867c-9238f3ad4bf0"), new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f06d4765-779a-4766-eb64-08db8a42133c"), "Embarking on a road trip is an exhilarating experience filled with freedom, adventure, and the open road stretching ahead. Proper preparation is vital to ensuring a smooth and enjoyable journey if you are planning a road trip and opting for a car rental. In this blog, we will guide you through essential steps and tips to follow when you hire a luxury car in Dubai. From choosing the right vehicle to planning your route and packing smartly, let’s dive into the details and make your road trip an unforgettable experience.Choose the Right Rental VehicleThe first step in preparing for your car rental adventure is selecting the ideal vehicle for your needs. Consider factors such as the number of passengers, luggage space requirements, and the terrain you will encounter. Whether you opt for a spacious SUV for a family trip, a fuel-efficient sedan for a solo adventure, or a luxurious convertible for a stylish getaway, choose a vehicle that suits your preferences and enhances your overall road trip experience.Research and Compare Rental Companies. With numerous car rental companies available, conducting thorough research and comparing their offerings is essential. Look for reputable companies that provide reliable vehicles, transparent pricing, and excellent customer service. Read reviews, check for hidden fees, and compare rental rates to ensure you get the best value. Additionally, consider rental policies, such as mileage limitations and insurance coverage, to make an informed decision.", "https://media.autoexpress.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1562255176/autoexpress/porsche-911-c4-cabriolet-1-front-cornering.jpg", false, "Road Trip Ready: Preparing for Your Car Rental Adventure" },
                    { new Guid("5374c53d-0bc2-4025-ab52-bc6d7f7897c9"), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f06d4765-779a-4766-eb64-08db8a42133c"), "Are you tired of the ordinary? Do you crave thrilling adventures that push your boundaries and ignite your sense of wanderlust? Look no further! Renting a G Wagon for off-road excursions is the perfect way to unleash your inner adventurer and embark on unforgettable journeys into the great outdoors. With its rugged design, exceptional performance, and luxurious features, the G Wagon is the ultimate companion for those seeking thrilling off-road experiences.This blog will explore why you should rent G Wagon for off-road excursions and what makes it an absolute game-changer. So fasten your seat belts and get ready for an adrenaline-pumping ride!Unparalleled Off-Road Capability. When it comes to conquering challenging terrains, the G Wagon is in a league of its own. With its robust build, advanced four-wheel-drive system, and high ground clearance, this formidable machine is built to handle any off-road obstacle that comes its way. So whether you are navigating steep inclines, crossing rocky landscapes, or fording through water bodies, the G Wagon’s off-road capability ensures that you stay in control and easily reach your destination.", "https://i0.wp.com/www.car-revs-daily.com/wp-content/uploads/2014/10/2015-BMW-X6-M-27.jpg?fit=2625%2C1281&ssl=1", false, "Unleash Your Inner Adventurer: Rent a G Wagon for Off-Road Excursions" },
                    { new Guid("d3f3cc89-7480-423f-959d-4ed070fceb18"), new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a5edc49-7490-493f-2f01-08db8a416485"), "If you have ever dreamed of feeling the luxurious thrill of having Italian engineering at your fingertips, then renting a Lamborghini Aventador could be the perfect way to live out that dream. This ultimate driving experience comes with everything from an innovative design and cutting-edge powertrain, to excellent handling capabilities and advanced safety features.But beyond some fantastic performance numbers, when you rent a Lamborghini Aventador Dubai, you enjoy access to exclusive amenities and services that give you an unforgettable drive every time. So if you are looking for something extraordinary behind the wheel, read on as we explore why renting a Lamborghini Aventador is worth every penny!1- Turn Heads Everywhere You Go:As one of the most iconic cars on the market, you can be sure that the Lamborghini Aventador will not fail to turn heads when you drive it. With its sharp lines and bold design, this car is an instant showstopper – giving you a chance to make a statement wherever you go.2- Feel Unmatched Power:When you rent a Lamborghini Aventador, you do not just get an impressive look, but also exceptional performance. Powered by a V12 engine with up to 740 horsepower, this car can take your driving experience to another level as it races from 0-60 in just 2.9 seconds!3- Enjoy Advanced Technology:The Lamborghini Aventador doesn’t just look great, but it also comes with several advanced technologies to enhance your drive. From a 12.3-inch TFT digital instrument cluster and an 8.4-inch touchscreen infotainment system to adaptive suspension and active aerodynamics – this car has it all!4- Receive Personalized Service:When you rent a Lamborghini Aventador, you get access to the exclusive services of the dealership. From 24/7 roadside assistance and custom detailing packages to personalized concierge services – they have got everything covered for you so that you can enjoy a hassle-free experience every time!5- Experience Luxury Like Never Before:Renting a Lamborghini Aventador allows you to experience true luxury like never before. From plush leather seating and high-end audio systems to aerodynamic body styling and other premium features – it is the perfect car for those who want an extraordinary driving experience.6- Unbeatable Price:Of course, the best part of all is that you can hire a Lamborghini Aventador in Dubai for an unbeatable price. Whether you choose to rent hourly or long-term, you will get access to exclusive offers and competitive rates – making it well worth every penny!", "https://www.digitaltrends.com/wp-content/uploads/2020/01/lamborghini_aventador_svj_roadster_1.jpg?fit=1500%2C1000&p=1", false, "Why Renting a Lamborghini Aventador is Worth Every Penny" }
                });
        }
    }
}
