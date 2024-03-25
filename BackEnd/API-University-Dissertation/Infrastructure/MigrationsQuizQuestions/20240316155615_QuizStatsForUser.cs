using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_University_Dissertation.MigrationsQuizQuestions
{
    /// <inheritdoc />
    public partial class QuizStatsForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileID",
                table: "UserQuizStatistics",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizStatistics_UserProfileID",
                table: "UserQuizStatistics",
                column: "UserProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizStatistics_UserProfiles_UserProfileID",
                table: "UserQuizStatistics",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizStatistics_UserProfiles_UserProfileID",
                table: "UserQuizStatistics");

            migrationBuilder.DropIndex(
                name: "IX_UserQuizStatistics_UserProfileID",
                table: "UserQuizStatistics");

            migrationBuilder.DropColumn(
                name: "UserProfileID",
                table: "UserQuizStatistics");
        }
    }
}
