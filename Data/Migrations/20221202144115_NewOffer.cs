using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class NewOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_windowsCleaningPreferences_Locations_LocationId",
                table: "windowsCleaningPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_windowsCleaningPreferences_Oferrents_OfferentId",
                table: "windowsCleaningPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_windowsCleaningPreferences",
                table: "windowsCleaningPreferences");

            migrationBuilder.RenameTable(
                name: "windowsCleaningPreferences",
                newName: "WindowsCleaningPreferences");

            migrationBuilder.RenameIndex(
                name: "IX_windowsCleaningPreferences_OfferentId",
                table: "WindowsCleaningPreferences",
                newName: "IX_WindowsCleaningPreferences_OfferentId");

            migrationBuilder.RenameIndex(
                name: "IX_windowsCleaningPreferences_LocationId",
                table: "WindowsCleaningPreferences",
                newName: "IX_WindowsCleaningPreferences_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WindowsCleaningPreferences",
                table: "WindowsCleaningPreferences",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 14, 41, 15, 62, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "CarpetWashingPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 14, 41, 15, 62, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 14, 41, 15, 62, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "CleaningPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 14, 41, 15, 62, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "District" },
                values: new object[] { 3, "Katowice", "Ligota" });

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 14, 41, 15, 62, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.InsertData(
                table: "WindowsCleaningPreferences",
                columns: new[] { "Id", "CreatedDate", "LocationId", "OfferentId", "PriceOffer", "Regularity", "UpdateDate" },
                values: new object[] { 1, new DateTime(2022, 12, 2, 14, 41, 15, 62, DateTimeKind.Utc).AddTicks(5186), 3, 2, 2000, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_WindowsCleaningPreferences_Locations_LocationId",
                table: "WindowsCleaningPreferences",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WindowsCleaningPreferences_Oferrents_OfferentId",
                table: "WindowsCleaningPreferences",
                column: "OfferentId",
                principalTable: "Oferrents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WindowsCleaningPreferences_Locations_LocationId",
                table: "WindowsCleaningPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_WindowsCleaningPreferences_Oferrents_OfferentId",
                table: "WindowsCleaningPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WindowsCleaningPreferences",
                table: "WindowsCleaningPreferences");

            migrationBuilder.DeleteData(
                table: "WindowsCleaningPreferences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "WindowsCleaningPreferences",
                newName: "windowsCleaningPreferences");

            migrationBuilder.RenameIndex(
                name: "IX_WindowsCleaningPreferences_OfferentId",
                table: "windowsCleaningPreferences",
                newName: "IX_windowsCleaningPreferences_OfferentId");

            migrationBuilder.RenameIndex(
                name: "IX_WindowsCleaningPreferences_LocationId",
                table: "windowsCleaningPreferences",
                newName: "IX_windowsCleaningPreferences_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_windowsCleaningPreferences",
                table: "windowsCleaningPreferences",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 13, 56, 52, 463, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "CarpetWashingPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 13, 56, 52, 463, DateTimeKind.Utc).AddTicks(1955));

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

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 13, 56, 52, 463, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.AddForeignKey(
                name: "FK_windowsCleaningPreferences_Locations_LocationId",
                table: "windowsCleaningPreferences",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_windowsCleaningPreferences_Oferrents_OfferentId",
                table: "windowsCleaningPreferences",
                column: "OfferentId",
                principalTable: "Oferrents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
