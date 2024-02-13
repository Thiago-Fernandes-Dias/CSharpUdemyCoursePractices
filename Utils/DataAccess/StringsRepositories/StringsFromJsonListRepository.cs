using System.Text;
using System.Text.Json;

namespace Utils.DataAccess.StringsRepository;

public class StringsFromJsonListRepository(string filePath) : IStringsRepository
{
    public List<string> Read()
    {
        if (!File.Exists(filePath))
        {
            return [];
        }
        var jsonString = File.ReadAllText(filePath);
        var namesFromFile = JsonSerializer.Deserialize<List<string>>(jsonString);
        return namesFromFile ?? [];
    }

    public void Write(List<string> strings)
    {
        if (!File.Exists(filePath))
        {
            using var newFile = File.Create(filePath);
            var jsonString = JsonSerializer.Serialize(strings);
            var bytes = Encoding.UTF8.GetBytes(jsonString);
            newFile.Write(bytes);
            return;
        }
        using var existingFile = File.Open(filePath, FileMode.OpenOrCreate);
        using var sw = new StreamWriter(existingFile);
        var point = existingFile.Length - 1;
        existingFile.Seek(point, SeekOrigin.Begin);
        sw.Write($", \"{string.Join(',', strings)}\"]");
        sw.Flush();
    }
}