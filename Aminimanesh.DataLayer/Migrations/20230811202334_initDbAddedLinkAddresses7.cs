using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initDbAddedLinkAddresses7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_LinkAddresses_LinkAddressId",
                table: "Histories");

            migrationBuilder.AlterColumn<int>(
                name: "LinkAddressId",
                table: "Histories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_LinkAddresses_LinkAddressId",
                table: "Histories",
                column: "LinkAddressId",
                principalTable: "LinkAddresses",
                principalColumn: "LinkAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_LinkAddresses_LinkAddressId",
                table: "Histories");

            migrationBuilder.AlterColumn<int>(
                name: "LinkAddressId",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_LinkAddresses_LinkAddressId",
                table: "Histories",
                column: "LinkAddressId",
                principalTable: "LinkAddresses",
                principalColumn: "LinkAddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
