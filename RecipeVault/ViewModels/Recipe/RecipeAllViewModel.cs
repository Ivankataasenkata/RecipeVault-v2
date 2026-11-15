namespace RecipeVault.ViewModels.Recipe
{
    public class RecipeAllViewModel
    {
        public int Id { get; set; }

        public string  Title  { get; set; } = null!;

        public string? ImageUrl  { get; set; }

        public int PrepTimeMinutes  { get; set; }

        public string Difficulty  { get; set; } = null!;

        public string CuisineName  { get; set; } = null!;

        public double AverageRating { get; set; }   // 0 when there are no reviews

        public int ReviewCount { get; set; }
    }
}