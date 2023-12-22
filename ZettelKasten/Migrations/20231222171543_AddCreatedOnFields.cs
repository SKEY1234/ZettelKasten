using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZettelKasten.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedOnFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creationdate",
                table: "notes");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "tags",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "notetagrelations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdon",
                table: "notes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "noterelations",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "notetagrelations");

            migrationBuilder.DropColumn(
                name: "createdon",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "noterelations");

            migrationBuilder.AddColumn<DateOnly>(
                name: "creationdate",
                table: "notes",
                type: "date",
                nullable: true);
        }
    }
}
