using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class VideoGameInfoSecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "The Last of Us Part II");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "The Last of Us Part I");
        }
    }
}
