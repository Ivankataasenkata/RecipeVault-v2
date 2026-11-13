using Microsoft.EntityFrameworkCore;
using RecipeVault.Data;
using RecipeVault.Models;
using RecipeVault.Services.Interfaces;
using RecipeVault.ViewModels.Recipe;

namespace RecipeVault.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext  dbContext;

        public RecipeService(ApplicationDbContext  dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<RecipeAllViewModel>> GetAllAsync()
        {
            return await dbContext.Recipes
                .AsNoTracking()
                .Select(r => new RecipeAllViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    ImageUrl = r.ImageUrl,
                    PrepTimeMinutes = r.PrepTimeMinutes,
                    Difficulty  = r.Difficulty.ToString(),
                    CuisineName  = r.Cuisine.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RecipeAllViewModel>> GetLatestAsync(int count)
        {
            return await dbContext.Recipes
                .AsNoTracking()
                .OrderByDescending(r => r.CreatedOn)   // newest first
                .Take(count)                           // only the few the home page shows
                .Select(r => new RecipeAllViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    ImageUrl = r.ImageUrl,
                    PrepTimeMinutes = r.PrepTimeMinutes,
                    Difficulty = r.Difficulty.ToString(),
                    CuisineName = r.Cuisine.Name
                })
                .ToListAsync();
        }

        public async Task<RecipeDetailsViewModel?> GetDetailsAsync(int id)
        {
            return await dbContext.Recipes
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new RecipeDetailsViewModel
                {
                     Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Instructions = r.Instructions,
                    PrepTimeMinutes = r.PrepTimeMinutes,
                    Servings = r.Servings,
                    Difficulty = r.Difficulty.ToString(),
                    ImageUrl = r.ImageUrl,
                    CreatedOn = r.CreatedOn,
                    CuisineName = r.Cuisine.Name,
                    Ingredients = r.RecipeIngredients
                        .Select(ri => ri.Quantity + " " + ri.Ingredient.Name)
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<RecipeFormViewModel> GetEmptyFormAsync()
        {
            return new RecipeFormViewModel
            {
                Cuisines = await GetCuisinesAsync()
            };
        }

        public async Task<RecipeFormViewModel?> GetForEditAsync(int id)
        {
            var model = await dbContext.Recipes
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new RecipeFormViewModel
                {
                   Title = r.Title,
                    Description = r.Description,
                    Instructions = r.Instructions,
                    PrepTimeMinutes = r.PrepTimeMinutes,
                    Servings = r.Servings,
                    Difficulty = r.Difficulty,
                    ImageUrl = r.ImageUrl,
                    CuisineId = r.CuisineId 
                })
                .FirstOrDefaultAsync();

            if (model != null)
            {
                model.Cuisines  = await GetCuisinesAsync();
            }

            return model;
        }

        public async Task<int> CreateAsync(RecipeFormViewModel  model)
        {
            var recipe = new Recipe
            {
                Title = model.Title,
                Description = model.Description,
                Instructions = model.Instructions,
                PrepTimeMinutes = model.PrepTimeMinutes,
                Servings = model.Servings,
                Difficulty = model.Difficulty,
                ImageUrl = model.ImageUrl,
                CuisineId = model.CuisineId,
                CreatedOn = DateTime.UtcNow
            };

            dbContext.Recipes.Add(recipe);
            await dbContext.SaveChangesAsync();
            return recipe.Id;
        }

        public async Task<bool> EditAsync(int id,RecipeFormViewModel  model)
        {
            var recipe = await dbContext.Recipes.FindAsync(id);

            if(recipe == null)
            {
                return false;
            }

            recipe.Title = model.Title;
            recipe.Description = model.Description;
            recipe.Instructions = model.Instructions;
            recipe.PrepTimeMinutes = model.PrepTimeMinutes;
            recipe.Servings = model.Servings;
            recipe.Difficulty = model.Difficulty;
            recipe.ImageUrl = model.ImageUrl;
            recipe.CuisineId = model.CuisineId;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recipe = await dbContext.Recipes.FindAsync(id);
            if(recipe == null)
            {
                return false;
            }

            dbContext.Recipes.Remove(recipe);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<CuisineDropdownViewModel>> GetCuisinesAsync()
        {
            return await dbContext.Cuisines
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new CuisineDropdownViewModel { Id = c.Id, Name = c.Name })
                .ToListAsync();
        }
    }
}