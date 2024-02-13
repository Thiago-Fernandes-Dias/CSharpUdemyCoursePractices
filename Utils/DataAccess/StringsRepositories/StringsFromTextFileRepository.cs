namespace Utils.DataAccess.StringsRepository;

public class StringsFromTextFileRepository(string filePath) : IStringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read()
    {
        if (!File.Exists(filePath))
        {
            return [];
        }
        var fileContents = File.ReadAllText(filePath);
        var stringsFromFile = fileContents.Split(Separator).Where(s => s != "").ToList();
        return stringsFromFile;
    }

    public void Write(List<string> strings)
    {
        var stringToWrite = string.Join(Separator, strings);
        using var streamWriter = File.AppendText(filePath);
        streamWriter.WriteLine(stringToWrite);
    }
}