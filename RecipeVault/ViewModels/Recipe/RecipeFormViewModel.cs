using System.ComponentModel.DataAnnotations;
using RecipeVault.Models;
using static RecipeVault.Common.ValidationConstants;

namespace RecipeVault.ViewModels.Recipe
{
    public class RecipeFormViewModel
    {
        [Required]
        [StringLength(RecipeTitleMaxLength, MinimumLength = RecipeTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(RecipeDescriptionMaxLength, MinimumLength = RecipeDescriptionMinLength)]
        public string Description  { get; set; } = null!;


        [Required]
        [StringLength(RecipeInstructionsMaxLength, MinimumLength = RecipeInstructionsMinLength)]
        public string Instructions  { get; set; } = null!;

        [Range(RecipePrepTimeMinutesMin, RecipePrepTimeMinutesMax)]
        [Display(Name = "Prep time (minutes)")]
        public int PrepTimeMinutes  { get; set; }


        [Range(RecipeServingsMin, RecipeServingsMax)]
        public int Servings  { get; set; }

        public Difficulty  Difficulty  { get; set; }
        [Url]
        [MaxLength(RecipeImageUrlMaxLength)]
        [Display(Name = "Image URL")]
        public string? ImageUrl  { get; set; }

        [Display(Name = "Cuisine")]
        public int CuisineId  { get; set; }

        public ICollection<CuisineDropdownViewModel> Cuisines  { get; set; } = new List<CuisineDropdownViewModel>();
    }
}