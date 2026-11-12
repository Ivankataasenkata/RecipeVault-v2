namespace RecipeVault.ViewModels.Recipe
{
    public class RecipeDetailsViewModel
    {
        public int Id  { get; set; }

        public string Title  { get; set; } = null!;

        public string Description  { get; set; } = null!;

        public string Instructions  { get; set; } = null!;

        public int PrepTimeMinutes  { get; set; }

        public int Servings  { get; set; }

        public string Difficulty  { get; set; } = null!;

        public string? ImageUrl  { get; set; }

        public DateTime CreatedOn  { get; set; }

        public string CuisineName  { get; set; } = null!;

        public ICollection<string> Ingredients  { get; set; } = new List<string>();
    }
}