using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_University_Dissertation.MigrationsQuizQuestions
{
    /// <inheritdoc />
    public partial class ProficencyLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProficiencyLevels",
                columns: new[] { "LevelId", "LevelName" },
                values: new object[] { 5, "Expert" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProficiencyLevels",
                keyColumn: "LevelId",
                keyValue: 5);
        }
    }
}
