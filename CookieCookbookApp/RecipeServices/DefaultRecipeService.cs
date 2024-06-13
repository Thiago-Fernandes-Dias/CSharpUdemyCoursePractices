using Utils.DataAccess.StringsRepository;

namespace CookieCookbookApp.RecipeServices;

public class DefaultRecipeService(IStringsRepository stringsRepository, List<Ingredient> availableIngredients) : RecipeService(availableIngredients)
{
    public override List<Recipe> ReadSavedRecipes()
    {
        List<Recipe> recipes = [];
        foreach (var s in stringsRepository.Read())
        {
            var recipeIngredientsIds = s.Split(',').Select(int.Parse);
            List<Ingredient> newRecipeIngredients = [];
            foreach (var id in recipeIngredientsIds)
            {
                var ingredient = AvailableIngredients.FirstOrDefault(i => i.Id == id);
                if (ingredient is not null)
                {
                    newRecipeIngredients.Add(ingredient);
                }
            }
            recipes.Add(new Recipe(newRecipeIngredients));
        }
        return recipes;
    }

    public override void SaveRecipe(Recipe recipe)
    {
        var recipesIds = recipe.Ingredients.Select(ingredient => $"{ingredient.Id}").ToList();
        var recipeString = string.Join(',', recipesIds);
        stringsRepository.Write([recipeString]);
    }
}