namespace RecipeVault.ViewModels.Recipe
{
    // One review as shown in the details page list.
    public class ReviewViewModel
    {
        public string AuthorName { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
