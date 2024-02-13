using System.Runtime.InteropServices;

namespace WhereLINQTest;

internal static class Program
{
    private static void Main(string[] args)
    {
        List<string> words = [];
        for (var i = 0; i < 20; i++)
        {
            words.Add("U" + i);
            words.Add("d" + i);
        }

        var uWords = words.WhereStartsWithU();
        var j = 5;
        foreach (var uWord in uWords)
        {
            Console.WriteLine(uWord);
            if (--j == 0) break;
        }

        j = 5;
        foreach (var uWord in uWords)
        {
            Console.WriteLine(uWord);
            if (--j == 0) break;
        }
    }

    private static IEnumerable<string> WhereStartsWithU(this IEnumerable<string> source)
    {
        foreach (var item in source)
        {
            if (!item.StartsWith("U")) continue;
            Console.WriteLine($"Yielded item: {item}");
            yield return item;
        }
    }

    public class Exercise
    {
        public void Test()
        {
            List<List<int>> listsOfIntList =
            [
                [1, 2, 3],
                [4, 5, 6],
                [7, 8, 9]
            ];
            var averages = listsOfIntList
                .Select(list => new { list.Count, Average = list.Average() });
            foreach (var average in averages)
                Console.WriteLine($"Count: {average.Count}, Average: {average.Average}");
        }
    }
}