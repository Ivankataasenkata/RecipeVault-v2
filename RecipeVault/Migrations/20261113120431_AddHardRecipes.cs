using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeVault.Migrations
{
    /// <inheritdoc />
    public partial class AddHardRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 11, "Mushrooms" },
                    { 12, "Butter" },
                    { 13, "Onion" },
                    { 14, "White wine" },
                    { 15, "Duck" },
                    { 16, "Honey" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CreatedOn", "CuisineId", "Description", "Difficulty", "ImageUrl", "Instructions", "PrepTimeMinutes", "Servings", "Title" },
                values: new object[,]
                {
                    { 4, new DateTime(2026, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Creamy Italian risotto that demands patience: constant stirring, good stock and a generous knob of butter.", 2, "https://images.unsplash.com/photo-1476124369491-e7addf5db371?w=800", "Soften the chopped onion and garlic in butter.\nAdd the rice and toast for two minutes.\nDeglaze with white wine.\nAdd hot stock one ladle at a time, stirring until absorbed before the next.\nFry the mushrooms separately and fold them in.\nFinish off the heat with butter and parmesan. Rest two minutes and serve.", 50, 4, "Mushroom Risotto" },
                    { 5, new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "The famous Chinese showpiece: lacquered crispy skin achieved through drying, glazing and careful roasting.", 2, "https://images.unsplash.com/photo-1582878826629-29b7ad1cdc43?w=800", "Clean the duck and pat it completely dry.\nBlanch the skin with boiling water, then dry again.\nBrush with the honey and soy glaze.\nLet the duck air-dry in the fridge overnight.\nRoast at high heat, glazing twice more, until the skin is deep mahogany and crisp.\nRest, carve thinly and serve with pancakes.", 180, 6, "Peking Duck" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Quantity" },
                values: new object[,]
                {
                    { 4, 4, "80 g" },
                    { 7, 4, "320 g" },
                    { 10, 4, "2 cloves" },
                    { 11, 4, "250 g" },
                    { 12, 4, "60 g" },
                    { 13, 4, "1" },
                    { 14, 4, "100 ml" },
                    { 9, 5, "3 tbsp" },
                    { 10, 5, "3 cloves" },
                    { 15, 5, "1 whole" },
                    { 16, 5, "4 tbsp" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 16, 5 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
