using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initDbAddedLinkAddresses2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkAddress_Histories_HistoryId",
                table: "LinkAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkAddress",
                table: "LinkAddress");

            migrationBuilder.RenameTable(
                name: "LinkAddress",
                newName: "LinkAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_LinkAddress_HistoryId",
                table: "LinkAddresses",
                newName: "IX_LinkAddresses_HistoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkAddresses",
                table: "LinkAddresses",
                column: "LinkAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkAddresses_Histories_HistoryId",
                table: "LinkAddresses",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "HistoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkAddresses_Histories_HistoryId",
                table: "LinkAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkAddresses",
                table: "LinkAddresses");

            migrationBuilder.RenameTable(
                name: "LinkAddresses",
                newName: "LinkAddress");

            migrationBuilder.RenameIndex(
                name: "IX_LinkAddresses_HistoryId",
                table: "LinkAddress",
                newName: "IX_LinkAddress_HistoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkAddress",
                table: "LinkAddress",
                column: "LinkAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkAddress_Histories_HistoryId",
                table: "LinkAddress",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "HistoryId");
        }
    }
}
