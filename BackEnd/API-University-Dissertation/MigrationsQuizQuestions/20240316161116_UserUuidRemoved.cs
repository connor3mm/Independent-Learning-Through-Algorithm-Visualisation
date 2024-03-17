using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_University_Dissertation.MigrationsQuizQuestions
{
    /// <inheritdoc />
    public partial class UserUuidRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserUUID",
                table: "UserQuizStatistics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserUUID",
                table: "UserQuizStatistics",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
