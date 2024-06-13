namespace Utils;

public class ConsoleInterface : IConsoleInterface
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }

    public void Write(string text)
    {
        Console.Write(text);
    }
}
