using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "OfferentId", "PostalCode", "Street" },
                values: new object[] { 1, "Orzesze", 1, "43-190", "Dworcowa" });

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 18, 27, 57, 481, DateTimeKind.Utc).AddTicks(3975));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 17, 18, 24, 52, 808, DateTimeKind.Utc).AddTicks(9579));
        }
    }
}
