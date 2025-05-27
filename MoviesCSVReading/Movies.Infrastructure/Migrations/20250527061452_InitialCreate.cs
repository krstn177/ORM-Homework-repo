using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    ImdbRating = table.Column<double>(type: "float", nullable: true),
                    Metascore = table.Column<double>(type: "float", nullable: true),
                    Votes = table.Column<int>(type: "int", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Director = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Cast = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gross = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
