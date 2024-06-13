using DiceRollApp;
using Moq;
using Utils;

namespace DiceRollAppTests;

[TestFixture]
public class GuessingManagerTests
{
    private readonly Mock<IUserInterface> _userInterfaceMock = new();
    private readonly Mock<IDiceRoller> _diceRollerMock = new();

    [SetUp]
    public void Setup()
    {
        _userInterfaceMock.Reset();
        _diceRollerMock.Reset();
    }

    [TestCase(5, 4)]
    [TestCase(4, 3)]
    [TestCase(3, 3)]
    [TestCase(2, 4)]
    public void Run_ShallWriteTheCorrectMessages_IfUserWinsInTheFirstTry(int tries, int correctGuess)
    {
        SetupCorrectGuessAndUserAttempts(correctGuess, [correctGuess]);
        var cut = new GuessingManager(tries, _diceRollerMock.Object, _userInterfaceMock.Object);
        cut.Run();
        VerifyDiceRolledAndWelcomeMessage(tries);
        _userInterfaceMock.Verify(ui => ui.ReadInteger(AppMessages.GuessTheNumber), Times.Once());
        _userInterfaceMock.Verify(ui => ui.ShowMessage(AppMessages.Win), Times.Once());
    }


    [TestCase(3, 4, new int[] { 1, 2, 4 })]
    [TestCase(4, 5, new int[] { 1, 2, 3, 5 } )]
    [TestCase(5, 6, new int[] { 1, 2, 3, 4, 6 })]
    public void Run_ShallWriteTheCorrectMessages_IfUserWinsInTheLastTry(int tries, int correctGuess, int[] userAttempts)
    {
        SetupCorrectGuessAndUserAttempts(correctGuess, userAttempts);
        var cut = new GuessingManager(tries, _diceRollerMock.Object, _userInterfaceMock.Object);
        cut.Run();
        VerifyDiceRolledAndWelcomeMessage(tries);
        _userInterfaceMock.Verify(ui => ui.ShowMessage(AppMessages.WrongChoice), Times.Exactly(userAttempts.Length - 1));
        _userInterfaceMock.Verify(ui => ui.ReadInteger(AppMessages.GuessTheNumber), Times.Exactly(userAttempts.Length));
        _userInterfaceMock.Verify(ui => ui.ShowMessage(AppMessages.Win), Times.Once());
    }

    [TestCase(3, 4, new int[] { 1, 2, 6 })]
    [TestCase(4, 5, new int[] { 1, 2, 3, 4 })]
    [TestCase(5, 6, new int[] { 1, 2, 3, 4, 5 })]
    public void Run_ShallWriteTheCorrectMessages_IfTheUserLoses(int tries, int correctGuess, int[] userAttempts)
    {
        SetupCorrectGuessAndUserAttempts(correctGuess, userAttempts);
        var cut = new GuessingManager(tries, _diceRollerMock.Object, _userInterfaceMock.Object);
        cut.Run();
        VerifyDiceRolledAndWelcomeMessage(tries);
        _userInterfaceMock.Verify(ui => ui.ShowMessage(AppMessages.WrongChoice), Times.Exactly(userAttempts.Length));
        _userInterfaceMock.Verify(ui => ui.ShowMessage(AppMessages.Lose), Times.Once());
    }

    private void SetupCorrectGuessAndUserAttempts(int correctGuess, int[] userAttempts)
    {
        _diceRollerMock.Setup(dr => dr.RollResult).Returns(correctGuess);
        var setupResult = _userInterfaceMock.SetupSequence(ui => ui.ReadInteger(It.IsAny<string>()));
        foreach (int attempt in userAttempts)
            setupResult.Returns(attempt);
    }

    private void VerifyDiceRolledAndWelcomeMessage(int tries)
    {
        var sequence = new MockSequence();
        _diceRollerMock.InSequence(sequence).Setup(dr => dr.RollDice());
        _userInterfaceMock.InSequence(sequence).Setup(ui => ui.ShowMessage(string.Format(AppMessages.DiceRolled, tries)));
    }
}
