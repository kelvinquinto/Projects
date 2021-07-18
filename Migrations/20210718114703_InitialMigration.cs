using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace covidAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "covid_observation",
                columns: table => new
                {
                    intId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dtmObservationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dtmLastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    strProvince = table.Column<string>(type: "text", nullable: true),
                    strCountry = table.Column<string>(type: "text", nullable: true),
                    intConfirmed = table.Column<int>(type: "integer", nullable: false),
                    intDeaths = table.Column<int>(type: "integer", nullable: false),
                    intRecovered = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_covid_observation", x => x.intId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "covid_observation");
        }
    }
}
