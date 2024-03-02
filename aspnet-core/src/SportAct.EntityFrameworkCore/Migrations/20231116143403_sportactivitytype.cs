using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class sportactivitytype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivityTypeId",
                table: "AppSportActivities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ActivityTypeName",
                table: "AppActivityTypes",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSportActivities_ActivityTypeId",
                table: "AppSportActivities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppActivityTypes_ActivityTypeName",
                table: "AppActivityTypes",
                column: "ActivityTypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSportActivities_AppActivityTypes_ActivityTypeId",
                table: "AppSportActivities",
                column: "ActivityTypeId",
                principalTable: "AppActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSportActivities_AppActivityTypes_ActivityTypeId",
                table: "AppSportActivities");

            migrationBuilder.DropIndex(
                name: "IX_AppSportActivities_ActivityTypeId",
                table: "AppSportActivities");

            migrationBuilder.DropIndex(
                name: "IX_AppActivityTypes_ActivityTypeName",
                table: "AppActivityTypes");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId",
                table: "AppSportActivities");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityTypeName",
                table: "AppActivityTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);
        }
    }
}
