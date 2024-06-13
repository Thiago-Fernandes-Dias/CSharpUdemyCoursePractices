namespace DiceRollApp;

public class DiceRoller : IDiceRoller
{
    public int RollResult { get; private set; } = 1;

    private readonly Random _random;
    private readonly int _sides;

    public DiceRoller(Random random, int sides)
    {
        _random = random;
        if (sides < 2)
            throw new ArgumentException("Invalid qty. of sides. It must be bigger than 2",
                                        nameof(sides));
        _sides = sides;
    }

    public void RollDice()
    {
        int num = _random.Next(2, _sides + 1);
        RollResult = num;
    }
}