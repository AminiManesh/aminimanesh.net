using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class urltitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlTitle",
                table: "Projects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlTitle",
                table: "Projects");
        }
    }
}
