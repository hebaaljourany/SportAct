using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class CityLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "AppLocations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppLocations_CityId",
                table: "AppLocations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppLocations_AppCities_CityId",
                table: "AppLocations",
                column: "CityId",
                principalTable: "AppCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppLocations_AppCities_CityId",
                table: "AppLocations");

            migrationBuilder.DropIndex(
                name: "IX_AppLocations_CityId",
                table: "AppLocations");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AppLocations");
        }
    }
}
