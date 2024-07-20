using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheUnlimited_Backend_.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TestAccesses",
                columns: new[] { "AgentLevelID", "TestID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestAccesses",
                keyColumns: new[] { "AgentLevelID", "TestID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TestAccesses",
                keyColumns: new[] { "AgentLevelID", "TestID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "TestAccesses",
                keyColumns: new[] { "AgentLevelID", "TestID" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
