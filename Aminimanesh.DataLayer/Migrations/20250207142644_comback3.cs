using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class comback3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_IpApiResponses_IpApiResponseId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "IpApiResponseId",
                table: "Messages",
                newName: "IpResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_IpApiResponseId",
                table: "Messages",
                newName: "IX_Messages_IpResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_IpApiResponses_IpResponseId",
                table: "Messages",
                column: "IpResponseId",
                principalTable: "IpApiResponses",
                principalColumn: "IpApiResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_IpApiResponses_IpResponseId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "IpResponseId",
                table: "Messages",
                newName: "IpApiResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_IpResponseId",
                table: "Messages",
                newName: "IX_Messages_IpApiResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_IpApiResponses_IpApiResponseId",
                table: "Messages",
                column: "IpApiResponseId",
                principalTable: "IpApiResponses",
                principalColumn: "IpApiResponseId");
        }
    }
}
