namespace DiceRollApp;

public interface IDiceRoller
{
    int RollResult { get; }

    void RollDice();
}