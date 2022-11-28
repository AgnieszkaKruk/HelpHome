using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 11, 34, 51, 203, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 11, 34, 51, 203, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 11, 34, 51, 203, DateTimeKind.Utc).AddTicks(4723));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 8, 54, 24, 182, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 8, 54, 24, 182, DateTimeKind.Utc).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 8, 54, 24, 182, DateTimeKind.Utc).AddTicks(6408));
        }
    }
}
