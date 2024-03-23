using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportAct.Migrations
{
    public partial class Reserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Participants",
                table: "AppReservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Participants",
                table: "AppReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
