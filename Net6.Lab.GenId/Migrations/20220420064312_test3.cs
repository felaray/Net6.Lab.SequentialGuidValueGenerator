using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net6.Lab.GenId.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WeatherForecastId",
                table: "Location",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_WeatherForecastId",
                table: "Location",
                column: "WeatherForecastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_WeatherForecast_WeatherForecastId",
                table: "Location",
                column: "WeatherForecastId",
                principalTable: "WeatherForecast",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_WeatherForecast_WeatherForecastId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_WeatherForecastId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "WeatherForecastId",
                table: "Location");
        }
    }
}
