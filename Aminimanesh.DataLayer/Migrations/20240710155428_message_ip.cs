using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class message_ip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIP",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "ActualIPAddress",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CloudflareActualIPAddress",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IpApiResponseId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RemoteIPAddress",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IpApiResponses",
                columns: table => new
                {
                    IpApiResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lon = table.Column<double>(type: "float", nullable: true),
                    ISP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpApiResponses", x => x.IpApiResponseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_IpApiResponseId",
                table: "Messages",
                column: "IpApiResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_IpApiResponses_IpApiResponseId",
                table: "Messages",
                column: "IpApiResponseId",
                principalTable: "IpApiResponses",
                principalColumn: "IpApiResponseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_IpApiResponses_IpApiResponseId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "IpApiResponses");

            migrationBuilder.DropIndex(
                name: "IX_Messages_IpApiResponseId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ActualIPAddress",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CloudflareActualIPAddress",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IpApiResponseId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RemoteIPAddress",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "UserIP",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
