using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initDbAddedWorkStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Awards",
                table: "Amins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompletedProjects",
                table: "Amins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Amins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SatisfiedCustomer",
                table: "Amins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Awards",
                table: "Amins");

            migrationBuilder.DropColumn(
                name: "CompletedProjects",
                table: "Amins");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Amins");

            migrationBuilder.DropColumn(
                name: "SatisfiedCustomer",
                table: "Amins");
        }
    }
}
