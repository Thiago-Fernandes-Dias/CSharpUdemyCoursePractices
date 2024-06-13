using System.Collections;

namespace UtilsTests;

[TestFixture]
public class EnumerableExtensionsTests
{
    [Test]
    public void SumOfEvenNumbers_ShallReturnZero_ForAnEmptyCollection()
    {
        var emptyEnumerable = Enumerable.Empty<int>();
        var sum = emptyEnumerable.SumOfEvenNumbers();
        Assert.AreEqual(0, sum);
    }

    [TestCase(12)]
    [TestCase(8)]
    [TestCase(4)]
    [TestCase(6)]
    [TestCase(2)]
    [TestCase(-2)]
    [TestCase(-6)]
    public void SumOfEvenNumbers_ShallReturnTheOneValue_IfItsEven(int number)
    {
        var list = new List<int>(1) { number };
        Assert.AreEqual(list.SumOfEvenNumbers(), number);
    }
    
    [TestCase(1)]
    [TestCase(3)]
    [TestCase(5)]
    [TestCase(7)]
    [TestCase(9)]
    [TestCase(-1)]
    [TestCase(-3)]
    [TestCase(-9)]
    public void SumOfEvenNumbers_ShallReturnZero_IfTheSingleItemIsOdd(int number)
    {
        var list = new List<int>(1) { number };
        Assert.AreEqual(list.SumOfEvenNumbers(), 0);
    }

    [TestCaseSource(nameof(GetSumOfEvenNumbersTestCases))]
    public void SumOfEvenNumbers_ShallReturnANonZeroResult_IfTheCollectionHasAnyEvenNumbers(IEnumerable<int> collection, int expected)
    {
        var result = collection.SumOfEvenNumbers();
        Assert.AreEqual(expected, result, $"The result should be {expected}, but was {result}");
    }
    
    [Test]
    public void SumOfEvenNumbers_ShallThrowAnNullRefException_ForANullInput()
    {
        IEnumerable<int>? input = null;
        Assert.Throws<NullReferenceException>(() => input!.SumOfEvenNumbers());
    }

    private static object[] GetSumOfEvenNumbersTestCases()
    {
        return
        [
            new object[] { new List<int> { 1, 2, 3, 18 }, 20 },
            new object[] { new int[] { 2, 6, -2, 1001 }, 6}
        ];
    }
}
