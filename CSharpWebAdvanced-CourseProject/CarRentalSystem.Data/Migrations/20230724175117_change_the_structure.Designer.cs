﻿// <auto-generated />
using System;
using CarRentalSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentalSystem.Data.Migrations
{
    [DbContext(typeof(CarRentingDbContext))]
    [Migration("20230724175117_change_the_structure")]
    partial class change_the_structure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentalSystem.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Acceleration")
                        .HasColumnType("float");

                    b.Property<int>("BodyType")
                        .HasColumnType("int");

                    b.Property<double>("Consumption")
                        .HasMaxLength(50)
                        .HasColumnType("float");

                    b.Property<int>("EngineType")
                        .HasColumnType("int");

                    b.Property<byte>("FuelAmount")
                        .HasColumnType("tinyint");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<long?>("Mileage")
                        .HasColumnType("bigint");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("PassengerSeats")
                        .HasMaxLength(8)
                        .HasColumnType("tinyint");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<byte?>("Safety")
                        .HasMaxLength(5)
                        .HasColumnType("tinyint");

                    b.Property<int>("TopSpeed")
                        .HasColumnType("int");

                    b.Property<int>("Transmission")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Acceleration = 2.8999999999999999,
                            BodyType = 3,
                            Consumption = 20.199999999999999,
                            EngineType = 2,
                            FuelAmount = (byte)0,
                            HorsePower = 637,
                            ImageUrl = "https://www.carpixel.net/w/fb81ff032f94a62ab3734238828ca57c/audi-rs-e-tron-gt-car-wallpaper-103179.jpg",
                            MakeId = 3,
                            Mileage = 5000L,
                            Model = "RS e-tron GT",
                            PassengerSeats = (byte)5,
                            PricePerDay = 420m,
                            Range = 298,
                            Safety = (byte)5,
                            TopSpeed = 155,
                            Transmission = 1,
                            Year = 2021
                        },
                        new
                        {
                            Id = 2,
                            Acceleration = 6.2000000000000002,
                            BodyType = 4,
                            Consumption = 6.2000000000000002,
                            EngineType = 1,
                            FuelAmount = (byte)0,
                            HorsePower = 261,
                            ImageUrl = "https://imagizer.imageshack.com/a/img29/5097/gu89.jpg",
                            MakeId = 3,
                            Mileage = 450000L,
                            Model = "A5 SB basic",
                            PassengerSeats = (byte)5,
                            PricePerDay = 329m,
                            Range = 520,
                            Safety = (byte)4,
                            TopSpeed = 126,
                            Transmission = 1,
                            Year = 2013
                        },
                        new
                        {
                            Id = 3,
                            Acceleration = 5.5,
                            BodyType = 1,
                            Consumption = 7.0999999999999996,
                            EngineType = 1,
                            FuelAmount = (byte)0,
                            HorsePower = 340,
                            ImageUrl = "https://avatars.mds.yandex.net/get-autoru-vos/5234682/06057d0f4b94a888f5c8112546a31a43/1200x900",
                            MakeId = 4,
                            Mileage = 53000L,
                            Model = "X6 40d",
                            PassengerSeats = (byte)5,
                            PricePerDay = 412m,
                            Range = 704,
                            Safety = (byte)4,
                            TopSpeed = 147,
                            Transmission = 1,
                            Year = 2012
                        },
                        new
                        {
                            Id = 4,
                            Acceleration = 3.6000000000000001,
                            BodyType = 18,
                            Consumption = 18.300000000000001,
                            EngineType = 1,
                            FuelAmount = (byte)0,
                            HorsePower = 483,
                            ImageUrl = "https://photos.carspecs.us/d389399428d2ba5d065c5b6f59aaf3771a41ca4b-2000.jpg",
                            MakeId = 6,
                            Mileage = 230532L,
                            Model = "F430",
                            PassengerSeats = (byte)2,
                            PricePerDay = 620m,
                            Range = 323,
                            Safety = (byte)3,
                            TopSpeed = 196,
                            Transmission = 1,
                            Year = 2004
                        },
                        new
                        {
                            Id = 5,
                            Acceleration = 5.4000000000000004,
                            BodyType = 0,
                            Consumption = 28.5,
                            EngineType = 1,
                            FuelAmount = (byte)0,
                            HorsePower = 280,
                            ImageUrl = "https://yandex-images.clstorage.net/e9YZ9F383/e3049dM4PtiR/48AJY79fj0JYkNVSm-meE7lJbsJRL_EQAcWW2JV-OOBHJ2BVk10QiQJdiHxO8fKyuG6pwiz5nm8PCEny6b7Z1NK0zce-6ioWORWV0qu5v8ZteH8H8WogtCQFEogQHpilMcGSV8QLx09Qqt-L3yTiZ70KPQcpHH25vkgrpF9seWMh0RtA-05t8g9z5_Cqisylaqsv5nI4ELLGtvL_QCnPA6CCMNV0ChQekVq9KB4HYBRvKVmkCxx-qMiI2odeP4uhIhMocsleX3EcQMfjS_j-plgLfQZBq5Mg9jcTn2DZDTDC40FUxYp0vNGoXFsM53B1DykZ1wqN7QlKeBl37VwJcFLiCSLr7c5R3vP0ULlKX4R5-Y9HMXhAspdUYI9yW4_hUsARxzQIJq7xCe-4v-SCVX9omqQI_r7I2iraxu_c6XBRkHjB-Uz_833jhODaqW_HSMitx4PbcSF0lFLd8NhM80Gg8MaGihVNAHnP-4xEwCZua5j2ec_8KsrI2qUtjJiBEFDI4qld3IO-slQiyvhuxZkKf8fxyuGRNuSQjxB7jBJiYfCW5OqljSFY7bmP5XDEvnnpJJrsDPsKeTnl3944U3HiaVCrf85SzABEcznbTuf6mH32gXly8BZmkX8wqH7BouHiZaWI9dzBqH_anRXgNp0622QbHExauspot9wMu-PCckjyqexdYu1QJgILKe9E2jh9FzLZQIC0dtKPY4ksIkCSQiVUOyVcYunsSx6mUYXvSRs1Kq8_Gis5WqZcTjhTQeIqAjkuHmI9QkYiashPVmk6PhZT-kFTBMXi3KGpnyGQg3L1VzrE_mJrjygs9jGmjdiYpriuTCr4edjW7o4a0OLQWmBbzi_R_IHWUfqp7hQ7yU6HgTox8Ce1gIyDe76Q00MSJPZalN7CGv5L7KQAlI4q2XaanoxoKnopl6yf-zMwkUhwq-5MU36iF9Cq6P2nmJtfRnH7EAL1t0Lfc",
                            MakeId = 2,
                            Mileage = 623142L,
                            Model = "Giulia",
                            PassengerSeats = (byte)5,
                            PricePerDay = 205m,
                            Range = 464,
                            Safety = (byte)4,
                            TopSpeed = 191,
                            Transmission = 0,
                            Year = 2018
                        },
                        new
                        {
                            Id = 6,
                            Acceleration = 4.5,
                            BodyType = 0,
                            Consumption = 22.699999999999999,
                            EngineType = 1,
                            FuelAmount = (byte)0,
                            HorsePower = 500,
                            ImageUrl = "https://sun9-46.userapi.com/impg/jGF9KYUrkOJ81ExMSYNNE4L7fh4GD5Ryoic6zA/Iy6iwscdEg0.jpg?size=1920x1280&quality=95&sign=637909ae3d1112f8306502533c876ba3&c_uniq_tag=3K2cQHcDOmacj7mo5PNx7wX_XCN3EOQggqEfBc4h6iI&type=album",
                            MakeId = 4,
                            Mileage = 575531L,
                            Model = "e60 M5",
                            PassengerSeats = (byte)5,
                            PricePerDay = 130m,
                            Range = 293,
                            Safety = (byte)3,
                            TopSpeed = 190,
                            Transmission = 1,
                            Year = 2005
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.CarColors", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "ColorId");

                    b.HasIndex("ColorId");

                    b.ToTable("CarsColors");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/T9T9.png",
                            Name = "Ibis White"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/6Y6Y.png",
                            Name = "Daytona Grey Pearl effect"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/9W9W.png",
                            Name = "Ascari Blue Metallic"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/Y1Y1.png",
                            Name = "Tango Red Metallic"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "https://cdn.nwi-ms.com/media/bg/A/mc/F83RJ7WT/color/V0V0.png",
                            Name = "Tactics Green Metallic"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NewInnovation")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Makes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Acura",
                            NewInnovation = "IntelliCruise"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alfa Romeo",
                            NewInnovation = "Active Aero Splitter"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Audi",
                            NewInnovation = "Virtual Cockpit Plus"
                        },
                        new
                        {
                            Id = 4,
                            Name = "BMW",
                            NewInnovation = "Gesture Control 2.0"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bentley",
                            NewInnovation = "Self-Leveling Air Suspension"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ferrari",
                            NewInnovation = "Side Slip Control"
                        });
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.UserRentals", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RentalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerId", "RentalId");

                    b.HasIndex("RentalId");

                    b.ToTable("UsersRentals");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Car", b =>
                {
                    b.HasOne("CarRentalSystem.Data.Models.Make", "Make")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.CarColors", b =>
                {
                    b.HasOne("CarRentalSystem.Data.Models.Car", "Car")
                        .WithMany("CarColors")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Data.Models.Color", "Color")
                        .WithMany("CarColors")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Contact", b =>
                {
                    b.HasOne("CarRentalSystem.Data.Models.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Rental", b =>
                {
                    b.HasOne("CarRentalSystem.Data.Models.Car", "Car")
                        .WithMany("Rentals")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.UserRentals", b =>
                {
                    b.HasOne("CarRentalSystem.Data.Models.User", "User")
                        .WithMany("UserRentals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Data.Models.Rental", "Rental")
                        .WithMany("UserRentals")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rental");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CarRentalSystem.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CarRentalSystem.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalSystem.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CarRentalSystem.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Car", b =>
                {
                    b.Navigation("CarColors");

                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Color", b =>
                {
                    b.Navigation("CarColors");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Make", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.Rental", b =>
                {
                    b.Navigation("UserRentals");
                });

            modelBuilder.Entity("CarRentalSystem.Data.Models.User", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("UserRentals");
                });
#pragma warning restore 612, 618
        }
    }
}