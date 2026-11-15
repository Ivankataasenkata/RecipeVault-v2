namespace RecipeVault.Common
{
    
    public static class ValidationConstants
    {
        // Cuisine
        public const int CuisineNameMinLength = 2;
        public const int CuisineNameMaxLength = 50;
        public const int CuisineDescriptionMaxLength = 500;

        public const int  RecipeTitleMinLength = 3;
        public const int  RecipeTitleMaxLength = 100;
        
        public const int RecipeDescriptionMinLength = 10;
        public const int RecipeDescriptionMaxLength = 2000;

        public const int RecipeInstructionsMinLength = 20;

         public const int RecipeInstructionsMaxLength = 5000;

         public const int RecipePrepTimeMinutesMin = 1;

         public const int RecipePrepTimeMinutesMax = 600;

        public const int RecipeServingsMin = 1;
        public const int RecipeServingsMax = 50;

        public const int RecipeImageUrlMaxLength = 2048;

        public const int IngredientNameMinLength = 2;

        public const int IngredientNameMaxLength = 50;


        public const int RecipeIngredientQuantityMinLength = 1;

        public const int RecipeIngredientQuantityMaxLength = 30;

        public const int ReviewAuthorNameMinLength = 2;
        public const int ReviewAuthorNameMaxLength = 50;
        public const int ReviewCommentMaxLength = 1000;
        public const int ReviewRatingMin = 1;
        public const int ReviewRatingMax = 5;
   
    }
}
