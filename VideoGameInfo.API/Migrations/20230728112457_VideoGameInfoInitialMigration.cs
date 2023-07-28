using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoGameInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class VideoGameInfoInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    DeveloperId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Naughty Dog, LLC (formerly JAM Software, Inc.) is an American first-party video game developer based in Santa Monica, California.", "Naughty Dog" },
                    { 2, "Rockstar North Limited (formerly DMA Design Limited) is a British video game development company and a studio of Rockstar Games based in Edinburgh.", "Rockstar North" },
                    { 3, "Konami Group Corporation, commonly known as Konami, is a Japanese multinational video game and entertainment company headquartered in Chūō, Tokyo.", "Konami" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DeveloperId", "Title" },
                values: new object[,]
                {
                    { 1, "The Last of Us Part II is a 2020 action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment for the PlayStation 4.", 1, "The Last of Us Part I" },
                    { 2, "Uncharted 4: A Thief's End is a 2016 action-adventure game developed by Naughty Dog and published by Sony Computer Entertainment.", 1, "Uncharted 4: A Thief's End" },
                    { 3, "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games.", 2, "Grand Theft Auto V" },
                    { 4, "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games.", 2, "Red Dead Redemption 2" },
                    { 5, "Metal Gear Solid is an action-adventure stealth video game developed and published by Konami for the PlayStation in 1998.", 3, "Metal Gear Solid" },
                    { 6, "Silent Hill is a 1999 survival horror game developed by Team Silent and published by Konami.", 3, "Silent Hill" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
