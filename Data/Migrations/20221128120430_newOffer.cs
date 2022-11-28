using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class newOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 12, 4, 29, 963, DateTimeKind.Utc).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 12, 4, 29, 963, DateTimeKind.Utc).AddTicks(3633));

            migrationBuilder.InsertData(
                table: "CleaningOffers",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Name", "PriceOffer", "Regularity", "SeekerId", "SurfaceToClean", "UpdateDate" },
                values: new object[] { 2, 1, new DateTime(2022, 11, 28, 12, 4, 29, 963, DateTimeKind.Utc).AddTicks(3647), "Sprzątanie", 50, 4, 1, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 12, 4, 29, 963, DateTimeKind.Utc).AddTicks(3681));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
