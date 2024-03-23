using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class Objects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppLocations_AppCities_CityId",
                table: "AppLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_AppReservations_AppClients_ClientId",
                table: "AppReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AppReservations_AppSportActivities_SportActivityId",
                table: "AppReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSportActivities_AppActivityTypes_ActivityTypeId",
                table: "AppSportActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSportActivities_AppLocations_LocationId",
                table: "AppSportActivities");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "AppSportActivities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivityTypeId",
                table: "AppSportActivities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SportActivityId",
                table: "AppReservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "AppReservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "AppLocations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AppLocations_AppCities_CityId",
                table: "AppLocations",
                column: "CityId",
                principalTable: "AppCities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppReservations_AppClients_ClientId",
                table: "AppReservations",
                column: "ClientId",
                principalTable: "AppClients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppReservations_AppSportActivities_SportActivityId",
                table: "AppReservations",
                column: "SportActivityId",
                principalTable: "AppSportActivities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSportActivities_AppActivityTypes_ActivityTypeId",
                table: "AppSportActivities",
                column: "ActivityTypeId",
                principalTable: "AppActivityTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSportActivities_AppLocations_LocationId",
                table: "AppSportActivities",
                column: "LocationId",
                principalTable: "AppLocations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppLocations_AppCities_CityId",
                table: "AppLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_AppReservations_AppClients_ClientId",
                table: "AppReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AppReservations_AppSportActivities_SportActivityId",
                table: "AppReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSportActivities_AppActivityTypes_ActivityTypeId",
                table: "AppSportActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSportActivities_AppLocations_LocationId",
                table: "AppSportActivities");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "AppSportActivities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ActivityTypeId",
                table: "AppSportActivities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SportActivityId",
                table: "AppReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "AppReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "AppLocations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppLocations_AppCities_CityId",
                table: "AppLocations",
                column: "CityId",
                principalTable: "AppCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppReservations_AppClients_ClientId",
                table: "AppReservations",
                column: "ClientId",
                principalTable: "AppClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppReservations_AppSportActivities_SportActivityId",
                table: "AppReservations",
                column: "SportActivityId",
                principalTable: "AppSportActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSportActivities_AppActivityTypes_ActivityTypeId",
                table: "AppSportActivities",
                column: "ActivityTypeId",
                principalTable: "AppActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSportActivities_AppLocations_LocationId",
                table: "AppSportActivities",
                column: "LocationId",
                principalTable: "AppLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
