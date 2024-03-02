using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class Async : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AppClients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AppClients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AppClients");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "AppClients");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "AppClients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppClients_UserId1",
                table: "AppClients",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppClients_AbpUsers_UserId1",
                table: "AppClients",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppClients_AbpUsers_UserId1",
                table: "AppClients");

            migrationBuilder.DropIndex(
                name: "IX_AppClients_UserId1",
                table: "AppClients");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AppClients");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AppClients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AppClients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AppClients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MobileNumber",
                table: "AppClients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
