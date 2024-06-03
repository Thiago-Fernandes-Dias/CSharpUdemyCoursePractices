using System.Diagnostics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        var text = "";
        stopwatch.Start();
        for (int i = 0; i < 10000; i++)
            text += "a";
        stopwatch.Stop();
        Console.WriteLine("{0,-15}|", stopwatch.ElapsedTicks);
        StringBuilder textbuilder = new();
        stopwatch.Restart();
        for (int i = 0; i < 10000; i++)
            textbuilder.Append('a');
        stopwatch.Stop();
        Console.WriteLine("{0,-15}|", stopwatch.ElapsedTicks);
    }

    public static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
    {
        for (int i = input.Count - 1; i >= 0; i--)
        {
            if (input[i] == null)
                yield break;
            yield return input[i];
        }
    }
}