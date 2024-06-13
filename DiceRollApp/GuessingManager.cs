using Utils;

namespace DiceRollApp;

public class GuessingManager
{
    private const int _defaultAttempts = 3;

    private readonly IDiceRoller _diceRoller;
    private readonly IUserInterface _userInterface;
    private readonly int _attempts;

    public GuessingManager(int attempts, IDiceRoller diceRoller, IUserInterface userInterface)
    {
        _diceRoller = diceRoller;
        _userInterface = userInterface;
        if (attempts <= 0)
        {
            _userInterface.ShowMessage(string.Format(AppMessages.InvalidQtyOfAttemps, _defaultAttempts));
            _attempts = _defaultAttempts;
        }
        else
        {
            _attempts = attempts;
        }
    }

    public async Task Run()
    {
        _diceRoller.RollDice();
        _userInterface.ShowMessage(string.Format(AppMessages.DiceRolled, _attempts));
        for (int i = 0; i < _attempts; i++)
        {
            var userChoice = _userInterface.ReadInteger(AppMessages.GuessTheNumber);
            if (userChoice == _diceRoller.RollResult)
            {
                _userInterface.ShowMessage(AppMessages.Win);
                return;
            }
            _userInterface.ShowMessage(AppMessages.WrongChoice);
        }
        _userInterface.ShowMessage(AppMessages.Lose);
    }
}