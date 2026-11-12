using RecipeVault.ViewModels.Recipe;

namespace RecipeVault.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeAllViewModel>> GetAllAsync();
        Task<RecipeDetailsViewModel?> GetDetailsAsync(int id);

        Task<RecipeFormViewModel> GetEmptyFormAsync();

        Task<RecipeFormViewModel?> GetForEditAsync(int id);

        Task<int> CreateAsync(RecipeFormViewModel  model);

        Task<bool> EditAsync (int id, RecipeFormViewModel  model);

        Task<bool> DeleteAsync(int id);
    }
}