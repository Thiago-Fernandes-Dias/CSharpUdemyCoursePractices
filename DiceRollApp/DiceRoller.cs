namespace DiceRollApp;

internal class DiceRoller
{
    private readonly Random _random;
    private int _rollResult;
    private readonly int _sides;

    public DiceRoller(Random random, int sides)
    {
        _random = random;
        if (sides < 1)
        {
            Console.WriteLine("Invalid number of sizes. Setting to 6.");
            _sides = 6;
        }
        else
        {
            _sides = sides;
        }    
    }

    public int RollResult
    {
        get
        {
            if (_rollResult == 0) throw new Exception("Dice not rolled");
            return _rollResult;
        }
        private set
        {
            if (DiceRolled) return;
            _rollResult = value;
        }
    }

    public bool DiceRolled => _rollResult != 0;

    public void RollDice()
    {
        int num = _random.Next(1, _sides + 1);
        RollResult = num;
    }
}