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
                new Ingredient { Id = 1, Name = "Spaghetti" },
                new Ingredient { Id = 2, Name = "Eggs" },
                new Ingredient { Id = 3, Name = "Bacon" },
                new Ingredient { Id = 4, Name = "Parmesan" },
                new Ingredient { Id = 5, Name = "Yogurt" },
                new Ingredient { Id = 6, Name = "Cucumber" },
                new Ingredient { Id = 7, Name = "Rice" },
                new Ingredient { Id = 8, Name = "Chicken" },
                new Ingredient { Id = 9, Name = "Soy sauce" },
                new Ingredient { Id = 10, Name = "Garlic" }
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
                new RecipeIngredient { RecipeId = 3, IngredientId = 10, Quantity = "2 cloves" }
            );
        }

    }
}

