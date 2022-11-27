using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AdministratorAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferrents_Roles_RoleId",
                table: "Oferrents");

            migrationBuilder.DropForeignKey(
                name: "FK_Seekers_Roles_RoleId",
                table: "Seekers");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Seekers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Oferrents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 27, 14, 47, 42, 512, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Administrator" });

            migrationBuilder.InsertData(
                table: "Oferrents",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[] { 2, "agak@wp.pl", "Aga Kruk", "#$%%^^&&", "444555333", 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Oferrents_Roles_RoleId",
                table: "Oferrents",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seekers_Roles_RoleId",
                table: "Seekers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferrents_Roles_RoleId",
                table: "Oferrents");

            migrationBuilder.DropForeignKey(
                name: "FK_Seekers_Roles_RoleId",
                table: "Seekers");

            migrationBuilder.DeleteData(
                table: "Oferrents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Seekers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Oferrents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "CleaningOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 27, 13, 53, 30, 440, DateTimeKind.Utc).AddTicks(6978));

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
    }
}
