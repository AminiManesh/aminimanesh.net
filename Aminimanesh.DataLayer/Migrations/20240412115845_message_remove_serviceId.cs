using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class message_remove_serviceId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Services_ServiceId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ServiceId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Messages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ServiceId",
                table: "Messages",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Services_ServiceId",
                table: "Messages",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId");
        }
    }
}
