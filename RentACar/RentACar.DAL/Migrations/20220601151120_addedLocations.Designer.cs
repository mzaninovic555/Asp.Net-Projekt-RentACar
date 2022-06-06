﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentACar.DAL;

#nullable disable

namespace RentACar.DAL.Migrations
{
    [DbContext(typeof(RentACarDbContext))]
    [Migration("20220601151120_addedLocations")]
    partial class addedLocations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RentACar.Model.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("OIB")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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

            modelBuilder.Entity("RentACar.Model.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("RentACar.Model.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<bool>("HasBluetooth")
                        .HasColumnType("bit");

                    b.Property<bool>("HasGps")
                        .HasColumnType("bit");

                    b.Property<bool>("HasParkingSensors")
                        .HasColumnType("bit");

                    b.Property<bool>("IsElectric")
                        .HasColumnType("bit");

                    b.Property<bool>("IsManual")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RentACar.Model.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CountryID = 1,
                            Name = "Zagreb",
                            PostalCode = 10000
                        },
                        new
                        {
                            ID = 2,
                            CountryID = 1,
                            Name = "Rijeka",
                            PostalCode = 51000
                        },
                        new
                        {
                            ID = 3,
                            CountryID = 1,
                            Name = "Split",
                            PostalCode = 21000
                        },
                        new
                        {
                            ID = 4,
                            CountryID = 1,
                            Name = "Dubrovnik",
                            PostalCode = 20000
                        },
                        new
                        {
                            ID = 5,
                            CountryID = 2,
                            Name = "New York",
                            PostalCode = 11368
                        },
                        new
                        {
                            ID = 6,
                            CountryID = 2,
                            Name = "Los Angeles",
                            PostalCode = 90011
                        },
                        new
                        {
                            ID = 7,
                            CountryID = 2,
                            Name = "Washington D.C.",
                            PostalCode = 20011
                        });
                });

            modelBuilder.Entity("RentACar.Model.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Hrvatska"
                        },
                        new
                        {
                            ID = 2,
                            Name = "United States"
                        });
                });

            modelBuilder.Entity("RentACar.Model.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PickupDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("StoreID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RentACar.Model.Store", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<TimeSpan>("OpenFrom")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("OpenTo")
                        .HasColumnType("time");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Vukovarska 41",
                            CityID = 1,
                            Email = "rentacar-zagreb@gmail.com",
                            OpenFrom = new TimeSpan(0, 6, 0, 0, 0),
                            OpenTo = new TimeSpan(0, 17, 0, 0, 0),
                            PhoneNumber = "01 3885 777"
                        },
                        new
                        {
                            ID = 2,
                            Address = "Zvonimirova 20 A",
                            CityID = 2,
                            Email = "rentacar-rijeka@gmail.com",
                            OpenFrom = new TimeSpan(0, 6, 0, 0, 0),
                            OpenTo = new TimeSpan(0, 16, 0, 0, 0),
                            PhoneNumber = "01 2314 019 "
                        },
                        new
                        {
                            ID = 3,
                            Address = "Vukovarska 182",
                            CityID = 3,
                            Email = "rentacar-split@gmail.com",
                            OpenFrom = new TimeSpan(0, 8, 0, 0, 0),
                            OpenTo = new TimeSpan(0, 15, 0, 0, 0),
                            PhoneNumber = "01 3310 050 "
                        },
                        new
                        {
                            ID = 4,
                            Address = "Sinjska 15",
                            CityID = 4,
                            Email = "rentacar-dubrovnik@gmail.com",
                            OpenFrom = new TimeSpan(0, 7, 0, 0, 0),
                            OpenTo = new TimeSpan(0, 14, 0, 0, 0),
                            PhoneNumber = "01 4552 590 "
                        },
                        new
                        {
                            ID = 5,
                            Address = "27 E 22nd St, NY 10010",
                            CityID = 5,
                            Email = "rentacar-newyork@gmail.com",
                            OpenFrom = new TimeSpan(0, 5, 0, 0, 0),
                            OpenTo = new TimeSpan(0, 22, 0, 0, 0),
                            PhoneNumber = "347 3917 724"
                        },
                        new
                        {
                            ID = 6,
                            Address = "9800 S Sepulveda Blvd, CA 90045",
                            CityID = 6,
                            Email = "rentacar-losangeles@gmail.com",
                            OpenFrom = new TimeSpan(0, 6, 0, 0, 0),
                            OpenTo = new TimeSpan(0, 21, 0, 0, 0),
                            PhoneNumber = "916 955 0339"
                        },
                        new
                        {
                            ID = 7,
                            Address = "923 16th St NW, DC 20006",
                            CityID = 7,
                            Email = "rentacar-washingtondc@gmail.com",
                            OpenFrom = new TimeSpan(0, 8, 0, 0, 0),
                            OpenTo = new TimeSpan(0, 20, 0, 0, 0),
                            PhoneNumber = "202 714 2570"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RentACar.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RentACar.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RentACar.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentACar.Model.Car", b =>
                {
                    b.HasOne("RentACar.Model.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("RentACar.Model.City", b =>
                {
                    b.HasOne("RentACar.Model.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RentACar.Model.Reservation", b =>
                {
                    b.HasOne("RentACar.Model.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Model.Store", "Store")
                        .WithMany("Reservations")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("RentACar.Model.Store", b =>
                {
                    b.HasOne("RentACar.Model.City", "City")
                        .WithMany("Stores")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("RentACar.Model.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentACar.Model.Car", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RentACar.Model.City", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("RentACar.Model.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("RentACar.Model.Store", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}