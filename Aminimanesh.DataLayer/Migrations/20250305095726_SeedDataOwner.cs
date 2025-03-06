using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aminimanesh.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "Age", "Avatar", "Awards", "CVFile", "City", "CompletedProjects", "Country", "Email", "ExperienceYears", "FirstJob", "FullName", "IncomeEmail", "Instagram", "Mobile", "Mobile2", "Province", "SatisfiedCustomer", "SecondJob", "Telegram", "Whatsapp" },
                values: new object[] { 1, 22, "./owner/img/thumbnails/avatar.jpg", "", "", "Arak", "4", "Iran", "aztecgoodamin1@gmail.com", "5", "Back-End Developer", " محمد امین امینی منش", "aztecgoodamin1@gmail.com", "amn.web", "09187622841", "09182565432", "Markazi", "2", "C# Programmer", "aminimanesh81", "+989187622841" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: 1);
        }
    }
}
