using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oferrents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferrents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Oferrents_OfferentId",
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpetWashingOffers", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningOffers", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowsCleaningOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WindowsCleaningOffers_Seekers_SeekerId",
                        column: x => x.SeekerId,
                        principalTable: "Seekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Oferrents",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "jdsks@com", "Jan Kowalski", "123456" },
                    { 2, "Ania@pl", "Ania Nowak", "234123111" }
                });

            migrationBuilder.InsertData(
                table: "Seekers",
                columns: new[] { "Id", "Email", "Name", "OfferentId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "jdsks@com", "Romuald Krawczyk", null, "123456" },
                    { 2, "Ania@pl", "Alicja Olos", null, "234123111" }
                });

            migrationBuilder.InsertData(
                table: "CleaningOffers",
                columns: new[] { "Id", "CreatedDate", "Name", "PriceOffer", "Regularity", "SeekerId", "SurfaceToClean", "UpdateDate" },
                values: new object[] { 1, new DateTime(2022, 11, 17, 18, 24, 52, 808, DateTimeKind.Utc).AddTicks(9579), "Sprzątanie", 50, 0, 1, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OfferentId",
                table: "Addresses",
                column: "OfferentId");

            migrationBuilder.CreateIndex(
                name: "IX_CarpetWashingOffers_SeekerId",
                table: "CarpetWashingOffers",
                column: "SeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningOffers_SeekerId",
                table: "CleaningOffers",
                column: "SeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seekers_OfferentId",
                table: "Seekers",
                column: "OfferentId");

            migrationBuilder.CreateIndex(
                name: "IX_WindowsCleaningOffers_SeekerId",
                table: "WindowsCleaningOffers",
                column: "SeekerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CarpetWashingOffers");

            migrationBuilder.DropTable(
                name: "CleaningOffers");

            migrationBuilder.DropTable(
                name: "WindowsCleaningOffers");

            migrationBuilder.DropTable(
                name: "Seekers");

            migrationBuilder.DropTable(
                name: "Oferrents");
        }
    }
}
