namespace Utils;

public static class EnumerableExtensions
{
    public static int SumOfEvenNumbers(this IEnumerable<int> numbers)
    {
        var result = 0;
        foreach (var number in numbers) 
            if (number % 2 == 0)
                result += number;
        return result;
    }
}
