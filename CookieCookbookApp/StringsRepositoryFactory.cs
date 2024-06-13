using Utils.DataAccess.StringsRepository;

namespace CookieCookbookApp;

public class StringsRepositoryFactory(string filePath)
{
    public IStringsRepository CreateRepository()
    {
        var fileFormat = filePath.Split('.').Last();
        return fileFormat switch
        {
            "json" => new StringsFromJsonListRepository(filePath),
            "txt" => new StringsFromTextFileRepository(filePath),
            _ => throw new ArgumentException("Invalid file format")
        };
    }
}
