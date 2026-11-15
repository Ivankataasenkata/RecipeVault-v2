using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeVault.Migrations
{
    /// <inheritdoc />
    public partial class AddReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorName", "Comment", "CreatedOn", "Rating", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Maria", "Tastes like Rome! The trick with taking it off the heat before adding eggs is golden.", new DateTime(2026, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 2, "Georgi", "Great recipe, I added a bit more parmesan.", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 3, "Elena", "Just like my grandmother makes it. Perfect for summer.", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 4, "Stefan", "Quick and tasty weeknight dinner.", new DateTime(2026, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 5, "Anna", "Took me an hour but absolutely worth the stirring.", new DateTime(2026, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 6, "Viktor", "Delicious but very hard to get the skin right on the first try.", new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
