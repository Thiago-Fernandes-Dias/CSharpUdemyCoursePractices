using CookieCookbookApp.RecipeServices;
using System.Collections.Generic;
using Utils;
using Utils.DataAccess.StringsRepository;

namespace CookieCookbookApp;

internal static class Program
{
    static void Main(string[] args)
    {
        List<Ingredient> availableIngredients = [
            new(name: "flour", id: 1, preparationInstructions: "mix with water"),
            new(name: "sugar", id: 2, preparationInstructions: "mix with water"),
            new(name: "butter", id: 3, preparationInstructions: "mix with water"),
            new(name: "chocolate chips", id: 4, preparationInstructions: "mix with water"),
            new(name: "water",
                id: 5,
                preparationInstructions: "mix with flour, sugar, butter, and chocolate chips"),
        ];
        StringsRepositoryFactory stringsRepositoryFactory = new(@"C:\Users\thiag\OneDrive\Área de Trabalho\recipes.txt");
        IStringsRepository stringsRepository = stringsRepositoryFactory.CreateRepository();
        DefaultRecipeService recipeService = new(stringsRepository, availableIngredients);
        var savedRecipes = recipeService.ReadSavedRecipes();
        RecipePrinter.PrintRecipes(savedRecipes);
        NewRecipeCreator newRecipeCreator = new(recipeService, new UserInput(Console.ReadLine));
        var createdRecipe = newRecipeCreator.CreateRecipe();
        if (createdRecipe is not null)
        {
            recipeService.SaveRecipe(createdRecipe);
            Console.WriteLine("Recipe added:");
            RecipePrinter.PrintRecipe(createdRecipe);
        }
        else
            Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
        ProgramClosing.ExitWithMessage("Press any key to exit...");
    }
}