using Utils;

namespace DiceRollApp;

internal class Program
{
    static void Main(string[] args)
    {
        IDiceRoller diceRoller = new DiceRoller(new Random(), 6);
        IUserInterface userInterface = new ConsoleUserInterface(new ConsoleInterface());
        GuessingManager guessingManager = new(3, diceRoller, userInterface);
        guessingManager.Run();
    }
}