using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weather.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MaxTemperature = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    MinTemperature = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    MaxHumidity = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    MinHumidity = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistMeasures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    Humidity = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistMeasures");

            migrationBuilder.DropTable(
                name: "Measures");
        }
    }
}
