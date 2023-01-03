using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AllOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Regularity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeekerId = table.Column<int>(type: "int", nullable: false),
                    SeekerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllOffers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CarpetWashingOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 15, 44, 34, 949, DateTimeKind.Utc).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "CarpetWashingPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 15, 44, 34, 949, DateTimeKind.Utc).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 15, 44, 34, 949, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "CleaningPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 15, 44, 34, 949, DateTimeKind.Utc).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 15, 44, 34, 949, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "WindowsCleaningPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 2, 15, 44, 34, 949, DateTimeKind.Utc).AddTicks(6859));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllOffers");

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

            migrationBuilder.UpdateData(
                table: "WindowsCleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 14, 41, 15, 62, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "WindowsCleaningPreferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 2, 14, 41, 15, 62, DateTimeKind.Utc).AddTicks(5186));
        }
    }
}
