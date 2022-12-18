using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 12, 2, 15, 946, DateTimeKind.Utc).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 12, 2, 15, 946, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "CleaningPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 12, 2, 15, 946, DateTimeKind.Utc).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 12, 2, 15, 946, DateTimeKind.Utc).AddTicks(4548));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 10, 51, 33, 148, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 10, 51, 33, 148, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "CleaningPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 10, 51, 33, 149, DateTimeKind.Utc).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 10, 51, 33, 149, DateTimeKind.Utc).AddTicks(1));
        }
    }
}
