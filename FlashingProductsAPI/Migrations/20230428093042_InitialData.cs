using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlashingProductsAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Cars" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Buildings" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreationDate", "Durationseconds", "Price", "StartDate", "Title", "TitleEN" },
                values: new object[] { 1, 1, new DateTime(2023, 4, 28, 12, 30, 41, 388, DateTimeKind.Local).AddTicks(4251), null, null, null, "مرسيدس", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreationDate", "Durationseconds", "Price", "StartDate", "Title", "TitleEN" },
                values: new object[] { 2, 1, new DateTime(2023, 4, 28, 12, 30, 41, 388, DateTimeKind.Local).AddTicks(6713), null, null, null, "اودي", "Audi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
