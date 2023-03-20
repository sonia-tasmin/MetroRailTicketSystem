using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Infrastructure.Migrations
{
    public partial class seat_TrainNameRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainName",
                schema: "config",
                table: "Seat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainName",
                schema: "config",
                table: "Seat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
