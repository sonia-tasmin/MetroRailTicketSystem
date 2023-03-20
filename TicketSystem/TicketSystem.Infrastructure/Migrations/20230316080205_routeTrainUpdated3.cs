using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Infrastructure.Migrations
{
    public partial class routeTrainUpdated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Route",
                schema: "config",
                table: "RouteTrain");

            migrationBuilder.DropColumn(
                name: "Train",
                schema: "config",
                table: "RouteTrain");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                schema: "config",
                table: "RouteTrain",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TrainId",
                schema: "config",
                table: "RouteTrain",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrain_RouteId",
                schema: "config",
                table: "RouteTrain",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrain_TrainId",
                schema: "config",
                table: "RouteTrain",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteTrain_Route_RouteId",
                schema: "config",
                table: "RouteTrain",
                column: "RouteId",
                principalSchema: "config",
                principalTable: "Route",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteTrain_Train_TrainId",
                schema: "config",
                table: "RouteTrain",
                column: "TrainId",
                principalSchema: "config",
                principalTable: "Train",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteTrain_Route_RouteId",
                schema: "config",
                table: "RouteTrain");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteTrain_Train_TrainId",
                schema: "config",
                table: "RouteTrain");

            migrationBuilder.DropIndex(
                name: "IX_RouteTrain_RouteId",
                schema: "config",
                table: "RouteTrain");

            migrationBuilder.DropIndex(
                name: "IX_RouteTrain_TrainId",
                schema: "config",
                table: "RouteTrain");

            migrationBuilder.DropColumn(
                name: "RouteId",
                schema: "config",
                table: "RouteTrain");

            migrationBuilder.DropColumn(
                name: "TrainId",
                schema: "config",
                table: "RouteTrain");

            migrationBuilder.AddColumn<string>(
                name: "Route",
                schema: "config",
                table: "RouteTrain",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Train",
                schema: "config",
                table: "RouteTrain",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
