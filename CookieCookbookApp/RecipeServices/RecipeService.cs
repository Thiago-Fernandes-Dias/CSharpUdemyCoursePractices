namespace CookieCookbookApp.RecipeServices;

public abstract class RecipeService(List<Ingredient> availableIngredients)
{
    public readonly List<Ingredient> AvailableIngredients = availableIngredients;

    public abstract List<Recipe> ReadSavedRecipes();

    public abstract void SaveRecipe(Recipe recipe);
}