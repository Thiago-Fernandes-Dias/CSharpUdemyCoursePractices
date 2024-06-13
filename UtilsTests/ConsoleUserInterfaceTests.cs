namespace UtilsTests;

[TestFixture]
public class ConsoleUserInterfaceTests
{
    private Mock<IConsoleInterface> _consoleInterfaceMock = new();

    [SetUp]
    public void Setup()
    {
        _consoleInterfaceMock.Reset();
    }

    [TestCase("Enter a number", "1")]
    [TestCase("Digit", "134")]
    [TestCase("Number", "01200")]
    [TestCase("Enter a digit", "    2")]
    [TestCase("Digit", "30    ")]
    [TestCase("Guess", " 30    ")]
    public void ReadInteger_ShallWriteTheGivenMessageAndReturnTheInteger_IfTheUserInsertANumberInTheConsole(string msg, string inputString)
    {
        SetupCIReadLineTo(inputString);
        var cut = CreateCut();
        Assert.That(cut.ReadInteger(msg), Is.EqualTo(int.Parse(inputString)));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(msg), Times.Once());
    }

    [Test]
    public void ReadInteger_ShallAskMultipleTimes_IntTheUserInputIsNotNumerical()
    {
        var userInputs = new List<string>() { "", " ", "abc", "a5", "5" };
        SetupCIReadLineSequence(userInputs);
        var message = "Enter a number: ";
        var cut = new ConsoleUserInterface(_consoleInterfaceMock.Object);
        Assert.That(cut.ReadInteger(message), Is.EqualTo(int.Parse(userInputs.Last())));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(message),
                                     Times.Exactly(userInputs.Count));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(Messages.IncorrectInput + Environment.NewLine),
                                     Times.Exactly(userInputs.Count - 1));
    }

    public void ReadInteger_ShallAskMultipleTimes_IntTheUserInputIsNotNumericalAndNotValid()
    {
        var userInputs = new List<string>() { "", " ", "abc", "a5", "-1", "5" };
        SetupCIReadLineSequence(userInputs);
        var message = "Enter a number: ";
        var cut = new ConsoleUserInterface(_consoleInterfaceMock.Object);
        Assert.That(cut.ReadInteger(message, n => n > 0), Is.EqualTo(int.Parse(userInputs.Last())));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(message),
                                     Times.Exactly(userInputs.Count));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(Messages.IncorrectInput + Environment.NewLine),
                                     Times.Exactly(userInputs.Count - 1));
    }


    [TestCase("Enter a string", "string")]
    [TestCase("Text", "Text")]
    [TestCase("Answer", "Five")]
    public void ReadString_ShallWriteTheGivenMessageAndReturnTheString_IfTheUserInputAValidString(string msg, string inputString)
    {
        SetupCIReadLineTo(inputString);
        var cut = CreateCut();
        Assert.That(cut.ReadString(msg), Is.EqualTo(inputString));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(msg), Times.Once());
    }

    [Test]
    public void ReadString_ShallAskMultipleTimes_IfTheUserInputIsNotNullOrEmpty()
    {
        var userInputs = new List<string>() { "", null, "abc"};
        SetupCIReadLineSequence(userInputs);
        var message = "Enter a string: ";
        var cut = CreateCut();
        Assert.That(cut.ReadString(message), Is.EqualTo(userInputs.Last()));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(message),
                                     Times.Exactly(userInputs.Count));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(Messages.IncorrectInput + Environment.NewLine),
                                     Times.Exactly(userInputs.Count - 1));
    }

    [Test]
    public void ReadString_ShallAskMultipleTimes_IfTheUserInputIsNotNullOrEmptyAndNotValid()
    {
        var userInputs = new List<string>() { "", null, "abc", "abcd"};
        SetupCIReadLineSequence(userInputs);
        var message = "Enter a string: ";
        var cut = CreateCut();
        Assert.That(cut.ReadString(message, str => str.Length > 3), Is.EqualTo(userInputs.Last()));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(message),
                                     Times.Exactly(userInputs.Count));
        _consoleInterfaceMock.Verify(consoleInterface => consoleInterface.Write(Messages.IncorrectInput + Environment.NewLine),
                                     Times.Exactly(userInputs.Count - 1));
    }

    private ConsoleUserInterface CreateCut()
    {
        return new ConsoleUserInterface(_consoleInterfaceMock.Object);
    }

    private void SetupCIReadLineTo(string inputString)
    {
        _consoleInterfaceMock.Setup(consoleInterface => consoleInterface.ReadLine()).Returns(inputString);
    }

    private void SetupCIReadLineSequence(List<string> userInputs)
    {
        var setupResult = _consoleInterfaceMock.SetupSequence(consoleInterface => consoleInterface.ReadLine());
        foreach (var userInput in userInputs)
            setupResult.Returns(userInput);
    }
}
