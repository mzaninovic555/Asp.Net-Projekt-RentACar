using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.DAL.Migrations
{
    public partial class addedCarsBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Volkswagen" },
                    { 2, "Toyota" },
                    { 3, "Tesla" },
                    { 4, "Mercedes" },
                    { 5, "Skoda" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "ID", "BrandID", "HasBluetooth", "HasGps", "HasParkingSensors", "IsElectric", "IsManual", "Model", "PictureURL", "ProductionYear", "SeatCount" },
                values: new object[,]
                {
                    { 1, 1, true, false, true, false, true, "Golf", "https://www.carparisonleasing.co.uk/media/responsive/blog_detail_image-1170/cc-uploads/24f6f155/volkswagen%20golf%20r.jpeg", 2020, 4 },
                    { 2, 2, true, true, true, true, false, "Prius", "https://www.autotrader.com/wp-content/uploads/2021/06/2022-toyota-prius-prime-front-right-side.jpg", 2022, 5 },
                    { 3, 2, true, false, false, false, true, "Civic", "https://www.oktan.hr/wp-content/uploads/2017/09/honda-civic-2017.jpg", 2017, 4 },
                    { 4, 3, true, true, true, true, false, "Model X", "https://media.wired.co.uk/photos/606d9b03dbc4c121710a3d36/16:9/w_2560%2Cc_limit/tesla1.jpg", 2016, 4 },
                    { 5, 4, true, true, true, false, true, "C class", "https://www.topgear.com/sites/default/files/cars-car/carousel/2018/06/18c0437_004.jpg", 2021, 4 },
                    { 6, 5, true, false, true, true, false, "Enyaq iV", "https://static1.hotcarsimages.com/wordpress/wp-content/uploads/2021/10/Skoda-Enyaq-iV-3.jpg?q=50&fit=crop&w=750&dpr=1.5", 2020, 7 },
                    { 7, 5, true, true, true, false, true, "Octavia", "https://cdn-hr.skoda.at/media/Theme_UIElement_Image_Small_Component.Theme_UIElement_Slideshow_Item_Image_Component/5767-86119-162082-162083-image-small/dh-991-400692/b3c3338d/1647894440/skoda-octavia-sportline-m62-exterior-01.jpg", 2022, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
