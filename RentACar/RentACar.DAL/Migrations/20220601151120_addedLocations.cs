using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.DAL.Migrations
{
    public partial class addedLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Hrvatska" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "United States" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryID", "Name", "PostalCode" },
                values: new object[,]
                {
                    { 1, 1, "Zagreb", 10000 },
                    { 2, 1, "Rijeka", 51000 },
                    { 3, 1, "Split", 21000 },
                    { 4, 1, "Dubrovnik", 20000 },
                    { 5, 2, "New York", 11368 },
                    { 6, 2, "Los Angeles", 90011 },
                    { 7, 2, "Washington D.C.", 20011 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "ID", "Address", "CityID", "Email", "OpenFrom", "OpenTo", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Vukovarska 41", 1, "rentacar-zagreb@gmail.com", new TimeSpan(0, 6, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), "01 3885 777" },
                    { 2, "Zvonimirova 20 A", 2, "rentacar-rijeka@gmail.com", new TimeSpan(0, 6, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0), "01 2314 019 " },
                    { 3, "Vukovarska 182", 3, "rentacar-split@gmail.com", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0), "01 3310 050 " },
                    { 4, "Sinjska 15", 4, "rentacar-dubrovnik@gmail.com", new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0), "01 4552 590 " },
                    { 5, "27 E 22nd St, NY 10010", 5, "rentacar-newyork@gmail.com", new TimeSpan(0, 5, 0, 0, 0), new TimeSpan(0, 22, 0, 0, 0), "347 3917 724" },
                    { 6, "9800 S Sepulveda Blvd, CA 90045", 6, "rentacar-losangeles@gmail.com", new TimeSpan(0, 6, 0, 0, 0), new TimeSpan(0, 21, 0, 0, 0), "916 955 0339" },
                    { 7, "923 16th St NW, DC 20006", 7, "rentacar-washingtondc@gmail.com", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 20, 0, 0, 0), "202 714 2570" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
