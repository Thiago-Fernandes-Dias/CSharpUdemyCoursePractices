namespace Utils;

public class UserInput(Func<string?> readerCallback)
{
    private readonly Func<string?> _readInputCallback = readerCallback;

    public int ReadNumber(string message)
    {
        Console.Write(message);
        if (int.TryParse(_readInputCallback(), out var result))
        {
            return result;
        }
        throw new UserInputException("Invalid text");
    }
}