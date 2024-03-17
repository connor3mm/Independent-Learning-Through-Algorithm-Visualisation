using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_University_Dissertation.MigrationsQuizQuestions
{
    /// <inheritdoc />
    public partial class ProficiencyLevelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProficiencyLevels",
                columns: new[] { "LevelId", "LevelName" },
                values: new object[,]
                {
                    { 1, "Undetermined" },
                    { 2, "Beginner" },
                    { 3, "Intermediate" },
                    { 4, "Advanced" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProficiencyLevels",
                keyColumn: "LevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProficiencyLevels",
                keyColumn: "LevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProficiencyLevels",
                keyColumn: "LevelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProficiencyLevels",
                keyColumn: "LevelId",
                keyValue: 4);
        }
    }
}
