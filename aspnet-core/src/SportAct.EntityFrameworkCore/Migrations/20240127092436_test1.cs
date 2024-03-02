using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
