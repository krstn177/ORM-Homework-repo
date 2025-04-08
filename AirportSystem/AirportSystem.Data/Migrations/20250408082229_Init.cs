using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlightStatusChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedAt",
                value: new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FlightStatusChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedAt",
                value: new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FlightStatusChanges",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedAt",
                value: new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlightStatusChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedAt",
                value: new DateTime(2025, 4, 6, 11, 21, 7, 608, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "FlightStatusChanges",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedAt",
                value: new DateTime(2025, 4, 7, 11, 21, 7, 610, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "FlightStatusChanges",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedAt",
                value: new DateTime(2025, 4, 8, 6, 21, 7, 610, DateTimeKind.Local).AddTicks(3023));
        }
    }
}
