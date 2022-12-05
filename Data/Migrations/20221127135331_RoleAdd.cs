using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RoleAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Oferrents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seekers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Seekers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Seekers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Oferrents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Oferrents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 27, 13, 53, 30, 440, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Seeker" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Offerent" });

            migrationBuilder.UpdateData(
                table: "Oferrents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RoleId" },
                values: new object[] { "#1234#", 2 });

            migrationBuilder.UpdateData(
                table: "Seekers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RoleId" },
                values: new object[] { "#4566#", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Seekers_RoleId",
                table: "Seekers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferrents_RoleId",
                table: "Oferrents",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oferrents_Roles_RoleId",
                table: "Oferrents",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seekers_Roles_RoleId",
                table: "Seekers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferrents_Roles_RoleId",
                table: "Oferrents");

            migrationBuilder.DropForeignKey(
                name: "FK_Seekers_Roles_RoleId",
                table: "Seekers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Seekers_RoleId",
                table: "Seekers");

            migrationBuilder.DropIndex(
                name: "IX_Oferrents_RoleId",
                table: "Oferrents");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Seekers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Seekers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Oferrents");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Oferrents");

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 18, 14, 4, 41, 0, DateTimeKind.Utc).AddTicks(4904));

            migrationBuilder.InsertData(
                table: "Oferrents",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[] { 2, "Ania@pl", "Ania Nowak", "234123111" });

            migrationBuilder.InsertData(
                table: "Seekers",
                columns: new[] { "Id", "Email", "Name", "OfferentId", "PhoneNumber" },
                values: new object[] { 2, "Ania@pl", "Alicja Olos", null, "234123111" });
        }
    }
}
