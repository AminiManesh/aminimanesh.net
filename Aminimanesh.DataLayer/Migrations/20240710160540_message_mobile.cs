using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class message_mobile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderMobile",
                table: "Messages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderMobile",
                table: "Messages");
        }
    }
}
