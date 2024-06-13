using CookieCookbookApp.RecipeServices;
using Utils;
using Utils.DataAccess.StringsRepository;

namespace CookieCookbookApp;

public class NewRecipeCreator(RecipeService recipeService, UserInput userInput)
{
    private readonly RecipeService _recipeService = recipeService;
    private readonly UserInput _userInput = userInput;

    public Recipe? CreateRecipe()
    {
        var availableIngredients = _recipeService.AvailableIngredients;
        PrintWelcomeMsgAndIngredients(availableIngredients);
        List<Ingredient> ingredientsList = [];
        while (true)
        {
            int ingredientId;
            try
            {
                ingredientId = _userInput.ReadNumber("Enter ingredient id: ");
                var ingredient = availableIngredients.Find(ingredient => ingredient.Id == ingredientId);
                if (ingredient is not null)
                {
                    ingredientsList.Add(ingredient);
                }
            }
            catch (UserInputException)
            {
                break;
            }
        }
        if (ingredientsList.Count == 0)
        {
            return null;
        }
        return new(ingredientsList);
    }

    private static void PrintWelcomeMsgAndIngredients(IEnumerable<Ingredient> availableIngredients)
    {
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        foreach (var ingredient in availableIngredients)
        {
            Console.WriteLine(ingredient);
        }
    }
}