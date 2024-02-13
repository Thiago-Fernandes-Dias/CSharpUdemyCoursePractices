using System.Runtime.InteropServices;
using Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiceRollApp;

internal class Program
{
    static void Main(string[] args)
    {
        DiceRoller diceRoller = new(new Random(), 6);
        UserInput userInput = new(Console.ReadLine);
        diceRoller.RollDice();
        GuessingManager guessingManager = new(3, diceRoller);
        while (guessingManager.HasAttempts)
        {
            int userChoice;
            try
            {
                userChoice = userInput.ReadNumber("Enter number: ");
            }
            catch (UserInputException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            if (guessingManager.verifyUserChoice(userChoice) == GuessingResult.RightChoice)
            {
                ProgramClosing.ExitWithMessage("You win");
            }
            else
            {
                Console.WriteLine("Wrong choice");
            }
        }
        ProgramClosing.ExitWithMessage("You lose");
    }
}