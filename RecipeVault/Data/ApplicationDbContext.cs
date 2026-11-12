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
        }

    }
}
