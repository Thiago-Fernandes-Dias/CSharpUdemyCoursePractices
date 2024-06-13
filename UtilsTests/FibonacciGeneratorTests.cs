namespace UtilsTests;

[TestFixture]
internal class FibonacciGeneratorTests
{
    [TestCase(-1)]
    [TestCase(-10)]
    [TestCase(-30)]
    public void Generate_ShouldThrowAArgumentEx_WhenTheLenghtIsLessThan0(int n)
    {
        Assert.Throws<ArgumentException>(() => FibonacciGenerator.Generate(n));
    }

    [TestCase(47)]
    [TestCase(90)]
    [TestCase(100)]
    public void Generate_ShouldThrowAArgumentEx_WhenTheLenghtIsMoreThan46(int n)
    {
        Assert.Throws<ArgumentException>(() => FibonacciGenerator.Generate(n));
    }

    [Test]
    public void Generates_ShoulReturnTheCorrectSequences_ForTheBaseCases()
    {
        Assert.AreEqual(Enumerable.Empty<int>(), FibonacciGenerator.Generate(0));
        Assert.AreEqual(new List<int>() { 0 }, FibonacciGenerator.Generate(1));
        Assert.AreEqual(new List<int>() { 0, 1 }, FibonacciGenerator.Generate(2));
    }

    [TestCaseSource(nameof(GenerateRandomInts))]
    public void Generate_ShouldReturnTheFibonacciSequence_ForAGivenLenght(int i)
    {
        var currentSequence = FibonacciGenerator.Generate(i);
        var ithElement = currentSequence.ElementAt(i - 1);
        var expectedIthElement = currentSequence.ElementAt(i - 2) + currentSequence.ElementAt(i - 3);
        Assert.AreEqual(expectedIthElement, ithElement);
    }

    private static List<int> GenerateRandomInts()
    {
        Random random = new();
        List<int> ints = [];
        for (int i = 0; i < 100; i++)
            ints.Add(random.Next(3, 47));
        return ints;
    }
}
