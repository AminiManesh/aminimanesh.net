using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class message_ip_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_IpApiResponses_IpApiResponseId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "IpApiResponseId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_IpApiResponses_IpApiResponseId",
                table: "Messages",
                column: "IpApiResponseId",
                principalTable: "IpApiResponses",
                principalColumn: "IpApiResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_IpApiResponses_IpApiResponseId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "IpApiResponseId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_IpApiResponses_IpApiResponseId",
                table: "Messages",
                column: "IpApiResponseId",
                principalTable: "IpApiResponses",
                principalColumn: "IpApiResponseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
