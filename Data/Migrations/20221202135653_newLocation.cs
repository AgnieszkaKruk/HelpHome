using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class newLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CarpetWashingPreferences",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CarpetWashingPreferences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 13, 56, 52, 463, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 13, 56, 52, 463, DateTimeKind.Utc).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "CleaningPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 13, 56, 52, 463, DateTimeKind.Utc).AddTicks(1943));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "District" },
                values: new object[] { 2, "Bytom", "Szombierki" });

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 13, 56, 52, 463, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.InsertData(
                table: "CarpetWashingPreferences",
                columns: new[] { "Id", "CarpetSize", "CreatedDate", "LocationId", "Name", "OfferentId", "PriceOffer", "UpdateDate" },
                values: new object[] { 1, 0, new DateTime(2022, 12, 2, 13, 56, 52, 463, DateTimeKind.Utc).AddTicks(1955), 2, "Pranie dywanów", 2, 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarpetWashingPreferences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CarpetWashingPreferences");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CarpetWashingPreferences",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");

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
    }
}
