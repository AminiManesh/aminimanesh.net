using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_LinkAddresses_LinkAddressId",
                table: "Histories");

            migrationBuilder.DropTable(
                name: "Amins");

            migrationBuilder.DropTable(
                name: "LinkAddresses");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Histories_LinkAddressId",
                table: "Histories");

            migrationBuilder.AddColumn<string>(
                name: "LinkAddress",
                table: "Histories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkLabel",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShowName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsImage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_Attachments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstJob = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondJob = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CVFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedProjects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatisfiedCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Awards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telegram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Whatsapp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Eitaa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TelegramLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LinkedInLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GithubLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ProjectId",
                table: "Attachments",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropColumn(
                name: "LinkAddress",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "LinkLabel",
                table: "Histories");

            migrationBuilder.CreateTable(
                name: "Amins",
                columns: table => new
                {
                    AminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Awards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompletedProjects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Eitaa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmailLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstJob = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GithubLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LinkedInLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SatisfiedCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondJob = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telegram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TelegramLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Whatsapp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amins", x => x.AminId);
                });

            migrationBuilder.CreateTable(
                name: "LinkAddresses",
                columns: table => new
                {
                    LinkAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkAddresses", x => x.LinkAddressId);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Pictures_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_LinkAddressId",
                table: "Histories",
                column: "LinkAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ProjectId",
                table: "Pictures",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_LinkAddresses_LinkAddressId",
                table: "Histories",
                column: "LinkAddressId",
                principalTable: "LinkAddresses",
                principalColumn: "LinkAddressId");
        }
    }
}
