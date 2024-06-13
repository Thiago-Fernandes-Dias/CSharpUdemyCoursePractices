namespace CookieCookbookApp;

public class Ingredient(string name, int id, string preparationInstructions)
{
    public readonly string Name = name;
    public readonly int Id = id;
    public readonly string PreparationInstructions = preparationInstructions;
    
    public override string ToString()
    {
        return $"{Id}. {Name}";
    }
}