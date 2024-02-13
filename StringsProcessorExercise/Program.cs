using System.Diagnostics.Tracing;

namespace StringsProcessorExercise;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var words = ProcessAll(["bobcat", "wolverine", "grizzly"]);
        foreach (var word in words) 
            Console.WriteLine(word);
        Console.ReadKey();
    }

    private static List<string> ProcessAll(List<string> words)
    {
        var stringsProcessors = new List<StringsProcessor>
        {
            new StringsTrimmingProcessor(),
            new StringsUppercaseProcessor()
        };
        List<string> result = words;
        foreach (var stringsProcessor in stringsProcessors)
            result = stringsProcessor.Process(result);
        return result;
    }
}

public class StringsProcessor
{
    public virtual List<string> Process(List<string> words)
    {
        return words;
    }
}

public class StringsTrimmingProcessor : StringsProcessor
{
    public override List<string> Process(List<string> words)
    {
        List<string> result = new();
        foreach (var word in words)
            result.Add(word[..(word.Length / 2)]);
        return result;
    }
}

public class StringsUppercaseProcessor : StringsProcessor
{
    public override List<string> Process(List<string> words)
    {
        List<string> result = [];
        result.AddRange(words.Select(word => word.ToUpper()));
        return result;
    }
}