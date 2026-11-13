using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeVault.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Pasta, pizza and the Mediterranean classics.", "Italian" },
                    { 2, "Traditional Balkan dishes.", "Bulgarian" },
                    { 3, "Wok, rice, noodles and bold flavors.", "Asian" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Spaghetti" },
                    { 2, "Eggs" },
                    { 3, "Bacon" },
                    { 4, "Parmesan" },
                    { 5, "Yogurt" },
                    { 6, "Cucumber" },
                    { 7, "Rice" },
                    { 8, "Chicken" },
                    { 9, "Soy sauce" },
                    { 10, "Garlic" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CreatedOn", "CuisineId", "Description", "Difficulty", "ImageUrl", "Instructions", "PrepTimeMinutes", "Servings", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The Roman classic: silky egg sauce, crispy bacon and plenty of parmesan.", 1, "https://images.unsplash.com/photo-1612874742237-6526221588e3?w=800", "Boil the spaghetti in salted water.\nFry the bacon until crisp.\nWhisk eggs with grated parmesan.\nDrain pasta, mix with bacon, remove from heat and stir in the egg mixture.\nServe immediately with extra parmesan.", 25, 4, "Spaghetti Carbonara" },
                    { 2, new DateTime(2026, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Refreshing Bulgarian cold soup with yogurt, cucumber and garlic.", 0, "https://images.unsplash.com/photo-1571091718767-18b5b1457add?w=800", "Dice the cucumber finely.\nWhisk the yogurt with cold water.\nAdd cucumber, crushed garlic, dill and walnuts.\nSalt to taste and chill before serving.", 15, 4, "Tarator" },
                    { 3, new DateTime(2026, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Quick wok-fried rice with chicken, garlic and soy sauce.", 0, "https://images.unsplash.com/photo-1603133872878-684f208fb84b?w=800", "Cook the rice and let it cool.\nStir-fry diced chicken until golden.\nAdd garlic, then the rice.\nSeason with soy sauce and fry on high heat.\nFinish with scrambled egg stirred through.", 30, 2, "Chicken Fried Rice" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "500 g" },
                    { 2, 1, "3" },
                    { 3, 1, "200 g" },
                    { 4, 1, "100 g" },
                    { 5, 2, "500 g" },
                    { 6, 2, "1 large" },
                    { 10, 2, "2 cloves" },
                    { 7, 3, "300 g" },
                    { 8, 3, "250 g" },
                    { 9, 3, "3 tbsp" },
                    { 10, 3, "2 cloves" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
