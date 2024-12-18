using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trace_Api.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarData",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Trucks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Trucks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Trips",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedEndTime",
                table: "Trips",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedStartTime",
                table: "Trips",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Trips",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Coordinates",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Coordinates",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarData",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ExpectedEndTime",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ExpectedStartTime",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Trips");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Coordinates",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Coordinates",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6,
                oldNullable: true);
        }
    }
}
