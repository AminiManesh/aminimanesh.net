using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class category_url_title : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlTitle",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlTitle",
                table: "Categories");
        }
    }
}
