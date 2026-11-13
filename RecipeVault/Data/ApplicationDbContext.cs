using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using RecipeVault.Models;

namespace RecipeVault.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Cuisine> Cuisines {get; set;} = null!;
        public DbSet<Ingredient> Ingredients {get; set;} = null!;
        public DbSet<RecipeIngredient> RecipeIngredients {get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new {ri.RecipeId, ri.IngredientId}); 

                SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder  modelBuilder)
        {
            modelBuilder.Entity<Cuisine>().HasData(
                new Cuisine { Id = 1, Name = "Italian", Description = "Pasta, pizza and the Mediterranean classics." },
                new Cuisine { Id = 2, Name = "Bulgarian", Description = "Traditional Balkan dishes." },
                new Cuisine { Id = 3, Name = "Asian", Description = "Wok, rice, noodles and bold flavors." }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Spaghetti" },
                new Ingredient { Id = 2, Name = "Eggs" },
                new Ingredient { Id = 3, Name = "Bacon" },
                new Ingredient { Id = 4, Name = "Parmesan" },
                new Ingredient { Id = 5, Name = "Yogurt" },
                new Ingredient { Id = 6, Name = "Cucumber" },
                new Ingredient { Id = 7, Name = "Rice" },
                new Ingredient { Id = 8, Name = "Chicken" },
                new Ingredient { Id = 9, Name = "Soy sauce" },
                new Ingredient { Id = 10, Name = "Garlic" },
                new Ingredient { Id = 11, Name = "Mushrooms" },
                new Ingredient { Id = 12, Name = "Butter" },
                new Ingredient { Id = 13, Name = "Onion" },
                new Ingredient { Id = 14, Name = "White wine" },
                new Ingredient { Id = 15, Name = "Duck" },
                new Ingredient { Id = 16, Name = "Honey" }
            );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                     Id = 1,
                    Title = "Spaghetti Carbonara",
                    Description = "The Roman classic: silky egg sauce, crispy bacon and plenty of parmesan.",
                    Instructions = "Boil the spaghetti in salted water.\nFry the bacon until crisp.\nWhisk eggs with grated parmesan.\nDrain pasta, mix with bacon, remove from heat and stir in the egg mixture.\nServe immediately with extra parmesan.",
                    PrepTimeMinutes = 25,
                    Servings = 4,
                    Difficulty = Difficulty.Medium,
                    ImageUrl = "https://images.unsplash.com/photo-1612874742237-6526221588e3?w=800",
                    CreatedOn = new DateTime(2026, 11, 1),
                    CuisineId = 1
                },

                new Recipe
                {
                    Id = 2,
                    Title = "Tarator",
                    Description = "Refreshing Bulgarian cold soup with yogurt, cucumber and garlic.",
                    Instructions = "Dice the cucumber finely.\nWhisk the yogurt with cold water.\nAdd cucumber, crushed garlic, dill and walnuts.\nSalt to taste and chill before serving.",
                    PrepTimeMinutes = 15,
                    Servings = 4,
                    Difficulty = Difficulty.Easy,
                    ImageUrl = "https://images.unsplash.com/photo-1571091718767-18b5b1457add?w=800",
                    CreatedOn = new DateTime(2026, 11, 2),
                    CuisineId = 2
                },
                new Recipe
                {
                    Id = 3,
                    Title = "Chicken Fried Rice",
                    Description = "Quick wok-fried rice with chicken, garlic and soy sauce.",
                    Instructions = "Cook the rice and let it cool.\nStir-fry diced chicken until golden.\nAdd garlic, then the rice.\nSeason with soy sauce and fry on high heat.\nFinish with scrambled egg stirred through.",
                    PrepTimeMinutes = 30,
                    Servings = 2,
                    Difficulty = Difficulty.Easy,
                    ImageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b?w=800",
                    CreatedOn = new DateTime(2026, 11, 3),
                    CuisineId = 3
                },
                new Recipe
                {
                    Id = 4,
                    Title = "Mushroom Risotto",
                    Description = "Creamy Italian risotto that demands patience: constant stirring, good stock and a generous knob of butter.",
                    Instructions = "Soften the chopped onion and garlic in butter.\nAdd the rice and toast for two minutes.\nDeglaze with white wine.\nAdd hot stock one ladle at a time, stirring until absorbed before the next.\nFry the mushrooms separately and fold them in.\nFinish off the heat with butter and parmesan. Rest two minutes and serve.",
                    PrepTimeMinutes = 50,
                    Servings = 4,
                    Difficulty = Difficulty.Hard,
                    ImageUrl = "https://images.unsplash.com/photo-1476124369491-e7addf5db371?w=800",
                    CreatedOn = new DateTime(2026, 11, 4),
                    CuisineId = 1
                },
                new Recipe
                {
                    Id = 5,
                    Title = "Peking Duck",
                    Description = "The famous Chinese showpiece: lacquered crispy skin achieved through drying, glazing and careful roasting.",
                    Instructions = "Clean the duck and pat it completely dry.\nBlanch the skin with boiling water, then dry again.\nBrush with the honey and soy glaze.\nLet the duck air-dry in the fridge overnight.\nRoast at high heat, glazing twice more, until the skin is deep mahogany and crisp.\nRest, carve thinly and serve with pancakes.",
                    PrepTimeMinutes = 180,
                    Servings = 6,
                    Difficulty = Difficulty.Hard,
                    ImageUrl = "https://images.unsplash.com/photo-1582878826629-29b7ad1cdc43?w=800",
                    CreatedOn = new DateTime(2026, 11, 5),
                    CuisineId = 3
                }
            );

            modelBuilder.Entity<RecipeIngredient>().HasData(
                 new RecipeIngredient { RecipeId = 1, IngredientId = 1, Quantity = "500 g" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 2, Quantity = "3" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 3, Quantity = "200 g" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 4, Quantity = "100 g" },
                new RecipeIngredient { RecipeId = 2, IngredientId = 5, Quantity = "500 g" },
                new RecipeIngredient { RecipeId = 2, IngredientId = 6, Quantity = "1 large" },
                new RecipeIngredient { RecipeId = 2, IngredientId = 10, Quantity = "2 cloves" },
                new RecipeIngredient { RecipeId = 3, IngredientId = 7, Quantity = "300 g" },
                new RecipeIngredient { RecipeId = 3, IngredientId = 8, Quantity = "250 g" },
                new RecipeIngredient { RecipeId = 3, IngredientId = 9, Quantity = "3 tbsp" },
                new RecipeIngredient { RecipeId = 3, IngredientId = 10, Quantity = "2 cloves" },
                new RecipeIngredient { RecipeId = 4, IngredientId = 7, Quantity = "320 g" },
                new RecipeIngredient { RecipeId = 4, IngredientId = 11, Quantity = "250 g" },
                new RecipeIngredient { RecipeId = 4, IngredientId = 12, Quantity = "60 g" },
                new RecipeIngredient { RecipeId = 4, IngredientId = 13, Quantity = "1" },
                new RecipeIngredient { RecipeId = 4, IngredientId = 14, Quantity = "100 ml" },
                new RecipeIngredient { RecipeId = 4, IngredientId = 4, Quantity = "80 g" },
                new RecipeIngredient { RecipeId = 4, IngredientId = 10, Quantity = "2 cloves" },
                new RecipeIngredient { RecipeId = 5, IngredientId = 15, Quantity = "1 whole" },
                new RecipeIngredient { RecipeId = 5, IngredientId = 16, Quantity = "4 tbsp" },
                new RecipeIngredient { RecipeId = 5, IngredientId = 9, Quantity = "3 tbsp" },
                new RecipeIngredient { RecipeId = 5, IngredientId = 10, Quantity = "3 cloves" }
            );
        }

    }
}

