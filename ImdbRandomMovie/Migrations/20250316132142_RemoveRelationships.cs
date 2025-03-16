using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImdbRandomMovie.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "name.basics.filtered",
                schema: "dbo",
                columns: table => new
                {
                    Nconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeathYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryProfession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnownForTitles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_name.basics.filtered", x => x.Nconst);
                });

            migrationBuilder.CreateTable(
                name: "title.akas.filtered",
                schema: "dbo",
                columns: table => new
                {
                    Tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ordering = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attributes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOriginalTitle = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title.akas.filtered", x => new { x.Tconst, x.Ordering });
                });

            migrationBuilder.CreateTable(
                name: "title.basics.filtered",
                schema: "dbo",
                columns: table => new
                {
                    Tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdult = table.Column<byte>(type: "tinyint", nullable: true),
                    StartYear = table.Column<short>(type: "smallint", nullable: true),
                    RuntimeMinutes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title.basics.filtered", x => x.Tconst);
                });

            migrationBuilder.CreateTable(
                name: "title.crew.filtered",
                schema: "dbo",
                columns: table => new
                {
                    Tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Directors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Writers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title.crew.filtered", x => x.Tconst);
                });

            migrationBuilder.CreateTable(
                name: "title.ratings.filtered",
                schema: "dbo",
                columns: table => new
                {
                    Tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: true),
                    NumVotes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title.ratings.filtered", x => x.Tconst);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "name.basics.filtered",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "title.akas.filtered",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "title.basics.filtered",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "title.crew.filtered",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "title.ratings.filtered",
                schema: "dbo");
        }
    }
}
