using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_University_Dissertation.MigrationsQuizQuestions
{
    /// <inheritdoc />
    public partial class UserToQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizStatistics_UserProfiles_UserProfileId",
                table: "UserQuizStatistics");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "UserQuizStatistics",
                newName: "UserProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuizStatistics_UserProfileId",
                table: "UserQuizStatistics",
                newName: "IX_UserQuizStatistics_UserProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizStatistics_UserProfiles_UserProfileID",
                table: "UserQuizStatistics",
                column: "UserProfileID",
                principalTable: "UserProfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizStatistics_UserProfiles_UserProfileID",
                table: "UserQuizStatistics");

            migrationBuilder.RenameColumn(
                name: "UserProfileID",
                table: "UserQuizStatistics",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuizStatistics_UserProfileID",
                table: "UserQuizStatistics",
                newName: "IX_UserQuizStatistics_UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizStatistics_UserProfiles_UserProfileId",
                table: "UserQuizStatistics",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
