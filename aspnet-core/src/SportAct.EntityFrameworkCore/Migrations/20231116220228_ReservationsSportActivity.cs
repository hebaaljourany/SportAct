using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class ReservationsSportActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ActivityName",
                table: "AppSportActivities",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SportActivityId",
                table: "AppReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppSportActivities_ActivityName",
                table: "AppSportActivities",
                column: "ActivityName");

            migrationBuilder.CreateIndex(
                name: "IX_AppReservations_SportActivityId",
                table: "AppReservations",
                column: "SportActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppReservations_AppSportActivities_SportActivityId",
                table: "AppReservations",
                column: "SportActivityId",
                principalTable: "AppSportActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppReservations_AppSportActivities_SportActivityId",
                table: "AppReservations");

            migrationBuilder.DropIndex(
                name: "IX_AppSportActivities_ActivityName",
                table: "AppSportActivities");

            migrationBuilder.DropIndex(
                name: "IX_AppReservations_SportActivityId",
                table: "AppReservations");

            migrationBuilder.DropColumn(
                name: "SportActivityId",
                table: "AppReservations");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityName",
                table: "AppSportActivities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);
        }
    }
}
