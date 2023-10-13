using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OlympicGames.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { "in", "Indoor" },
                    { "ou", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "pa", "Paralympic Games" },
                    { "so", "Summer Olympics" },
                    { "wo", "Winter Olympics" },
                    { "yog", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryID", "FlagImage", "GameID", "Name" },
                values: new object[,]
                {
                    { "aus", "ou", "austria.jpg", "pa", "Austria" },
                    { "bra", "ou", "brazil.jpg", "so", "Brazil" },
                    { "can", "in", "canada.jpg", "wo", "Canada" },
                    { "chi", "in", "china.jpg", "so", "China" },
                    { "cyp", "in", "cyprus.jpg", "yog", "Cyprus" },
                    { "fin", "ou", "finland.jpg", "yog", "Finland" },
                    { "fra", "in", "france.jpg", "yog", "France" },
                    { "gb", "in", "great_britain.jpg", "wo", "Great Britain" },
                    { "ger", "in", "germany.jpg", "so", "Germany" },
                    { "ita", "ou", "italy.jpg", "wo", "Italy" },
                    { "jam", "ou", "jamaica.jpg", "wo", "Jamaica" },
                    { "jap", "ou", "japan.jpg", "wo", "Japan" },
                    { "mex", "in", "mexico.jpg", "so", "Mexico" },
                    { "net", "ou", "netherlands.jpg", "so", "Netherlands" },
                    { "pak", "ou", "pakistan.jpg", "pa", "Pakistan" },
                    { "por", "ou", "portugal.jpg", "yog", "Portugal" },
                    { "rus", "in", "russia.jpg", "yog", "Russia" },
                    { "slo", "ou", "slovakia.jpg", "yog", "Slovakia" },
                    { "swe", "in", "sweden.jpg", "wo", "Sweden" },
                    { "tha", "in", "thailand.jpg", "pa", "Thailand" },
                    { "ukr", "in", "ukraine.jpg", "pa", "Ukraine" },
                    { "uru", "in", "uruguay.jpg", "pa", "Uruguay" },
                    { "usa", "ou", "united_states.jpg", "so", "USA" },
                    { "zim", "ou", "zimbabwe.jpg", "pa", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryID",
                table: "Countries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
