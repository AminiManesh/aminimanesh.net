using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initDbAddedLinkAddresses3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkAddresses_Histories_HistoryId",
                table: "LinkAddresses");

            migrationBuilder.DropIndex(
                name: "IX_LinkAddresses_HistoryId",
                table: "LinkAddresses");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "LinkAddresses");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_LinkAddressId",
                table: "Histories",
                column: "LinkAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_LinkAddresses_LinkAddressId",
                table: "Histories",
                column: "LinkAddressId",
                principalTable: "LinkAddresses",
                principalColumn: "LinkAddressId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_LinkAddresses_LinkAddressId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_LinkAddressId",
                table: "Histories");

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "LinkAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LinkAddresses_HistoryId",
                table: "LinkAddresses",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkAddresses_Histories_HistoryId",
                table: "LinkAddresses",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "HistoryId");
        }
    }
}
