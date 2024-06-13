namespace Utils;

public interface IConsoleInterface
{
    public void Write(string text);

    public string? ReadLine();
}