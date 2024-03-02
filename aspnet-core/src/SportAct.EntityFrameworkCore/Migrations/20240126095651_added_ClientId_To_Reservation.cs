using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class added_ClientId_To_Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "AppReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppReservations_ClientId",
                table: "AppReservations",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppReservations_AppClients_ClientId",
                table: "AppReservations",
                column: "ClientId",
                principalTable: "AppClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppReservations_AppClients_ClientId",
                table: "AppReservations");

            migrationBuilder.DropIndex(
                name: "IX_AppReservations_ClientId",
                table: "AppReservations");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "AppReservations");
        }
    }
}
