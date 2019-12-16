using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFNewFeature.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrewerTypes",
                columns: table => new
                {
                    BrewerTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewerTypes", x => x.BrewerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    OpenTime = table.Column<string>(nullable: true),
                    CloseTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    BrewerTypeId = table.Column<int>(nullable: false),
                    WaterTemperature = table.Column<int>(nullable: false),
                    GrindSize = table.Column<int>(nullable: false),
                    GrindOunces = table.Column<int>(nullable: false),
                    WaterOunces = table.Column<int>(nullable: false),
                    BrewMinutes = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.BrewerTypeId);
                    table.ForeignKey(
                        name: "FK_Recipes_BrewerTypes_BrewerTypeId",
                        column: x => x.BrewerTypeId,
                        principalTable: "BrewerTypes",
                        principalColumn: "BrewerTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<Guid>(nullable: true),
                    BrewTypeBrewerTypeId = table.Column<int>(nullable: true),
                    Acquired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_BrewerTypes_BrewTypeBrewerTypeId",
                        column: x => x.BrewTypeBrewerTypeId,
                        principalTable: "BrewerTypes",
                        principalColumn: "BrewerTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BrewerTypes",
                columns: new[] { "BrewerTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Glass Hourglass Drip" },
                    { 2, "Hand Press" },
                    { 3, "Cold Brew" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "CloseTime", "OpenTime", "StreetAddress" },
                values: new object[] { new Guid("09236e34-5f9e-437c-a04a-a9155659c084"), "4PM", "6AM", "999 Main Street" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "Acquired", "BrewTypeBrewerTypeId", "LocationId" },
                values: new object[] { 2, new DateTime(2018, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "BrewerTypeId", "BrewMinutes", "Description", "GrindOunces", "GrindSize", "WaterOunces", "WaterTemperature" },
                values: new object[] { 1, 3, "so good", 5, 2, 1, 60 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "Acquired", "BrewTypeBrewerTypeId", "LocationId" },
                values: new object[] { 1, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("09236e34-5f9e-437c-a04a-a9155659c084") });

            migrationBuilder.CreateIndex(
                name: "IX_Units_BrewTypeBrewerTypeId",
                table: "Units",
                column: "BrewTypeBrewerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_LocationId",
                table: "Units",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "BrewerTypes");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
