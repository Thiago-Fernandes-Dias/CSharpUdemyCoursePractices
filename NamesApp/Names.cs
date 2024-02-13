class Names
{
    public List<string> All { get; } = [];
    private readonly NamesValidator _namesValidator = new();

    public void AddName(string name)
    {
        if (_namesValidator.IsValid(name))
        {
            All.Add(name);
        }
    }

    public void AddNames(List<string> stringsFromFile)
    {
        foreach (var name in stringsFromFile)
        {
            GC.Collect();

            AddName(name);
        }
    }
}
