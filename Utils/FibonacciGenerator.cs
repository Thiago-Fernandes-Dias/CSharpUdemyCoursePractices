namespace Utils;

public static class FibonacciGenerator
{
    public static IEnumerable<int> Generate(int n)
    {
        if (n < 0 || n > 46)
        {
            var msg = $"{nameof(n)} should be equal or bigger than 0 and less than 46";
            throw new ArgumentException(msg, nameof(n));
        }
        if (n == 0)
            return [];
        else if (n == 1)
            return [0];
        List<int> result = [0, 1];
        for (int i = 2; i < n; i++)
            result.Add(result[i - 1] + result[i - 2]);
        return result;
    }
}
