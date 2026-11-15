using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RecipeVault.Common.ValidationConstants;

namespace RecipeVault.Models
{
    public class Recipe
    {
        [Key]
        public int Id {get; set;}
        
        [Required]
        [MaxLength(RecipeTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(RecipeDescriptionMaxLength)]
        public string Description { get; set; } = null!;
        
        [Required]
        [MaxLength(RecipeInstructionsMaxLength)]
        public string Instructions { get; set; } = null!;

        public int PrepTimeMinutes {get;set;} 

        public int Servings { get; set; }  

        public Difficulty Difficulty { get; set; }

        [MaxLength(RecipeImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CuisineId { get; set; }

        [ForeignKey(nameof(CuisineId))]
        public virtual Cuisine Cuisine { get; set; } = null!;

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new HashSet<RecipeIngredient>();

        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
