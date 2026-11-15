using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static RecipeVault.Common.ValidationConstants;

namespace RecipeVault.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ReviewAuthorNameMaxLength)]
        public string AuthorName { get; set; } = null!;

        // 1 to 5 stars; the range is enforced in the view model.
        public int Rating { get; set; }

        [MaxLength(ReviewCommentMaxLength)]
        public string? Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
