using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Oferrents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferrents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oferrents_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Oferrents_OfferentId",
                        column: x => x.OfferentId,
                        principalTable: "Oferrents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarpetWashingPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarpetSize = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceOffer = table.Column<int>(type: "int", nullable: false),
                    OfferentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpetWashingPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarpetWashingPreferences_Oferrents_OfferentId",
                        column: x => x.OfferentId,
                        principalTable: "Oferrents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CleaningPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Regularity = table.Column<int>(type: "int", nullable: false),
                    PriceOffer = table.Column<int>(type: "int", nullable: false),
                    OfferentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CleaningPreferences_Oferrents_OfferentId",
                        column: x => x.OfferentId,
                        principalTable: "Oferrents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seekers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    OfferentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seekers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seekers_Oferrents_OfferentId",
                        column: x => x.OfferentId,
                        principalTable: "Oferrents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seekers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "windowsCleaningPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Regularity = table.Column<int>(type: "int", nullable: false),
                    PriceOffer = table.Column<int>(type: "int", nullable: false),
                    OfferentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_windowsCleaningPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_windowsCleaningPreferences_Oferrents_OfferentId",
                        column: x => x.OfferentId,
                        principalTable: "Oferrents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarpetWashingOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarpetCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Regularity = table.Column<int>(type: "int", nullable: false),
                    PriceOffer = table.Column<int>(type: "int", nullable: false),
                    SeekerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpetWashingOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarpetWashingOffers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarpetWashingOffers_Seekers_SeekerId",
                        column: x => x.SeekerId,
                        principalTable: "Seekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CleaningOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Regularity = table.Column<int>(type: "int", nullable: false),
                    SurfaceToClean = table.Column<int>(type: "int", nullable: false),
                    PriceOffer = table.Column<int>(type: "int", nullable: false),
                    SeekerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CleaningOffers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CleaningOffers_Seekers_SeekerId",
                        column: x => x.SeekerId,
                        principalTable: "Seekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WindowsCleaningOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Regularity = table.Column<int>(type: "int", nullable: false),
                    WindowsCount = table.Column<int>(type: "int", nullable: false),
                    PriceOffer = table.Column<int>(type: "int", nullable: false),
                    SeekerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowsCleaningOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WindowsCleaningOffers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WindowsCleaningOffers_Seekers_SeekerId",
                        column: x => x.SeekerId,
                        principalTable: "Seekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "OfferentId", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Orzesze", null, "43-190", "Dworcowa" },
                    { 2, "Mikołów", null, "43-190", "Majowa" },
                    { 3, "Katowice", null, "43-190", "Głogowa" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Seeker" },
                    { 2, "Offerent" },
                    { 3, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Oferrents",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 1, "jdsks@com", "Jan Kowalski", "#1234#", "123456", 2 },
                    { 2, "agak@wp.pl", "Aga Kruk", "#$%%^^&&", "444555333", 3 }
                });

            migrationBuilder.InsertData(
                table: "Seekers",
                columns: new[] { "Id", "Email", "Name", "OfferentId", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 1, "jdsks@com", "Janian", null, "#1234#", "123456", 1 },
                    { 2, "agak@wp.pl", "Zsoia", null, "#$%%^^&&", "444555333", 1 }
                });

            migrationBuilder.InsertData(
                table: "CarpetWashingOffers",
                columns: new[] { "Id", "AddressId", "CarpetCount", "CreatedDate", "Name", "PriceOffer", "Regularity", "SeekerId", "UpdateDate" },
                values: new object[] { 1, 2, 1, new DateTime(2022, 12, 5, 13, 18, 32, 967, DateTimeKind.Utc).AddTicks(9366), "Pranie dywanów", 110, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "CleaningOffers",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Name", "PriceOffer", "Regularity", "SeekerId", "SurfaceToClean", "UpdateDate" },
                values: new object[] { 1, 1, new DateTime(2022, 12, 5, 13, 18, 32, 967, DateTimeKind.Utc).AddTicks(9340), "Sprzątanie", 50, 0, 1, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "WindowsCleaningOffers",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Name", "PriceOffer", "Regularity", "SeekerId", "UpdateDate", "WindowsCount" },
                values: new object[] { 1, 3, new DateTime(2022, 12, 5, 13, 18, 32, 967, DateTimeKind.Utc).AddTicks(9391), "Mycie okien", 50, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 });

            migrationBuilder.InsertData(
                table: "windowsCleaningPreferences",
                columns: new[] { "Id", "CreatedDate", "OfferentId", "PriceOffer", "Regularity", "UpdateDate" },
                values: new object[] { 1, new DateTime(2022, 12, 5, 13, 18, 32, 967, DateTimeKind.Utc).AddTicks(9416), 1, 300, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OfferentId",
                table: "Addresses",
                column: "OfferentId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetWashingOffers_AddressId",
                table: "CarpetWashingOffers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetWashingOffers_SeekerId",
                table: "CarpetWashingOffers",
                column: "SeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetWashingPreferences_OfferentId",
                table: "CarpetWashingPreferences",
                column: "OfferentId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningOffers_AddressId",
                table: "CleaningOffers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningOffers_SeekerId",
                table: "CleaningOffers",
                column: "SeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningPreferences_OfferentId",
                table: "CleaningPreferences",
                column: "OfferentId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferrents_RoleId",
                table: "Oferrents",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Seekers_OfferentId",
                table: "Seekers",
                column: "OfferentId");

            migrationBuilder.CreateIndex(
                name: "IX_Seekers_RoleId",
                table: "Seekers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WindowsCleaningOffers_AddressId",
                table: "WindowsCleaningOffers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_WindowsCleaningOffers_SeekerId",
                table: "WindowsCleaningOffers",
                column: "SeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_windowsCleaningPreferences_OfferentId",
                table: "windowsCleaningPreferences",
                column: "OfferentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarpetWashingOffers");

            migrationBuilder.DropTable(
                name: "CarpetWashingPreferences");

            migrationBuilder.DropTable(
                name: "CleaningOffers");

            migrationBuilder.DropTable(
                name: "CleaningPreferences");

            migrationBuilder.DropTable(
                name: "WindowsCleaningOffers");

            migrationBuilder.DropTable(
                name: "windowsCleaningPreferences");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Seekers");

            migrationBuilder.DropTable(
                name: "Oferrents");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
