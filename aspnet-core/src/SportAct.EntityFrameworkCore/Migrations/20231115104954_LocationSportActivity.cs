using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class LocationSportActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "AppSportActivities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "AppLocations",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSportActivities_LocationId",
                table: "AppSportActivities",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppLocations_LocationName",
                table: "AppLocations",
                column: "LocationName");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSportActivities_AppLocations_LocationId",
                table: "AppSportActivities",
                column: "LocationId",
                principalTable: "AppLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSportActivities_AppLocations_LocationId",
                table: "AppSportActivities");

            migrationBuilder.DropIndex(
                name: "IX_AppSportActivities_LocationId",
                table: "AppSportActivities");

            migrationBuilder.DropIndex(
                name: "IX_AppLocations_LocationName",
                table: "AppLocations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AppSportActivities");

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "AppLocations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);
        }
    }
}
