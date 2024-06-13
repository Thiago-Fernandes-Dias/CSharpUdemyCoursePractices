using DiceRollApp;
using Moq;

namespace DiceRollAppTests;

[TestFixture]
public class DiceRollerTests
{
    private Mock<Random> _randomMock;

    [SetUp]
    public void Setup()
    {
        _randomMock = new Mock<Random>();
    }

    [TestCase(-1)]
    [TestCase(-2)]
    [TestCase(-3)]
    [TestCase(0)]
    [TestCase(1)]
    public void Constructor_ShallThrowsAnArgumentException_IfSidesIsLessThan2(int invalidSidesQty)
    {
        Assert.That(() => new DiceRoller(_randomMock.Object, invalidSidesQty), Throws.TypeOf<ArgumentException>());
    }

    [TestCase(2)]
    [TestCase(3)]
    [TestCase(6)]
    public void Constructor_ShallWorkCorrectly_ForAValidQtyOfSides(int validSidesQty)
    {
        Assert.That(() => new DiceRoller(_randomMock.Object, validSidesQty), Throws.Nothing);
    }

    [TestCase(7)]
    [TestCase(9)]
    [TestCase(10)]
    public void RollDice_ShallSetTheRollResult_WhenCalled(int sides)
    {
        _randomMock.Setup(random => random.Next(2, sides + 1)).Returns(6);
        var cut = new DiceRoller(_randomMock.Object, sides);
        cut.RollDice();
        Assert.That(cut.RollResult, Is.EqualTo(6));
    }
}