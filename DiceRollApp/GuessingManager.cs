using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollApp;

internal class GuessingManager
{
    private int _attempts;
    private readonly DiceRoller _diceRoller;
    private const int _defaultAttempts = 3;

    public GuessingManager(int attempts, DiceRoller diceRoller)
    {
        if (attempts <= 0)
        {
            Console.WriteLine($"Invalid quantity of attempts. Setting to {_defaultAttempts}");
            _attempts = _defaultAttempts;
        }
        else
        {
            _attempts = attempts;
        }
        _diceRoller = diceRoller;
    }

    public GuessingResult verifyUserChoice(int number)
    {
        if (!_diceRoller.DiceRolled)
            _diceRoller.RollDice();
        if (_attempts == 0)
            return GuessingResult.NoMoreAttempts;
        _attempts--;
        return number == _diceRoller.RollResult ? GuessingResult.RightChoice : GuessingResult.WrongChoice;
    }

    public bool HasAttempts => _attempts > 0;
}