using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Infrastructure.Migrations
{
    public partial class seatForeignKeyNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_RouteTrain_TrainId",
                schema: "config",
                table: "Seat");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                schema: "config",
                table: "Seat",
                newName: "RouteTrainId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_TrainId",
                schema: "config",
                table: "Seat",
                newName: "IX_Seat_RouteTrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_RouteTrain_RouteTrainId",
                schema: "config",
                table: "Seat",
                column: "RouteTrainId",
                principalSchema: "config",
                principalTable: "RouteTrain",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_RouteTrain_RouteTrainId",
                schema: "config",
                table: "Seat");

            migrationBuilder.RenameColumn(
                name: "RouteTrainId",
                schema: "config",
                table: "Seat",
                newName: "TrainId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_RouteTrainId",
                schema: "config",
                table: "Seat",
                newName: "IX_Seat_TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_RouteTrain_TrainId",
                schema: "config",
                table: "Seat",
                column: "TrainId",
                principalSchema: "config",
                principalTable: "RouteTrain",
                principalColumn: "Id");
        }
    }
}
