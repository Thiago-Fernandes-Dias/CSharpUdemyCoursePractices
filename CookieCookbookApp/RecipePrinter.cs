namespace CookieCookbookApp;

public class RecipePrinter
{
    public static void PrintRecipe(Recipe recipe)
    {
        foreach (var ingredient in recipe.Ingredients)
        {
            Console.WriteLine($"{ingredient.Name}. {ingredient.PreparationInstructions}");
        }
    }

    public static void PrintRecipes(List<Recipe> recipes)
    {
        if (recipes.Count == 0)
        {
            return;
        }
        Console.WriteLine("Existing recipes are:");
        for (var i = 1; i <= recipes.Count; i++)
        {
            Console.WriteLine($"**********{i}**********");
            PrintRecipe(recipes[i - 1]);
        }
    }
}