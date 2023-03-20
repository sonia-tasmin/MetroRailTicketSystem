using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Infrastructure.Migrations
{
    public partial class TrainIdAddedInSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TrainId",
                schema: "config",
                table: "Seat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TrainId",
                schema: "config",
                table: "Seat",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_RouteTrain_TrainId",
                schema: "config",
                table: "Seat",
                column: "TrainId",
                principalSchema: "config",
                principalTable: "RouteTrain",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_RouteTrain_TrainId",
                schema: "config",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_TrainId",
                schema: "config",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "TrainId",
                schema: "config",
                table: "Seat");
        }
    }
}
