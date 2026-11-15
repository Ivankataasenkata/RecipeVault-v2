using System.ComponentModel.DataAnnotations;

using static RecipeVault.Common.ValidationConstants;

namespace RecipeVault.ViewModels.Recipe
{
    // What a visitor posts when leaving a review.
    public class ReviewFormViewModel
    {
        public int RecipeId { get; set; }

        [Required]
        [StringLength(ReviewAuthorNameMaxLength, MinimumLength = ReviewAuthorNameMinLength)]
        [Display(Name = "Your name")]
        public string AuthorName { get; set; } = null!;

        [Range(ReviewRatingMin, ReviewRatingMax)]
        public int Rating { get; set; } = 5;

        [MaxLength(ReviewCommentMaxLength)]
        public string? Comment { get; set; }
    }
}
