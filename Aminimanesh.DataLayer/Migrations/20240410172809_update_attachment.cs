using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class update_attachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiniDescription",
                table: "Projects",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Attachments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Attachments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Projects",
                newName: "MiniDescription");
        }
    }
}
