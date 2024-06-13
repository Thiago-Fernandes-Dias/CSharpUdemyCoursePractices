namespace Utils;

public class ConsoleUserInterface(IConsoleInterface consoleInterface) : IUserInterface
{
    public int ReadInteger(string message)
    {
        return ReadInteger(message, _ => true);
    }

    public int ReadInteger(string message, Func<int, bool> validationDel)
    {
        while (true)
        {
            consoleInterface.Write(message);
            if (int.TryParse(consoleInterface.ReadLine(), out int number) && validationDel(number))
                return number;
            consoleInterface.Write(Messages.IncorrectInput + Environment.NewLine);
        }
    }

    public string ReadString(string message)
    {
        return ReadString(message, _ => true);
    }

    public string ReadString(string message, Func<string, bool> validationDel)
    {
        while (true)
        {
            consoleInterface.Write(message);
            var result = consoleInterface.ReadLine();
            if (!string.IsNullOrEmpty(result) && validationDel(result))
                return result;
            consoleInterface.Write(Messages.IncorrectInput + Environment.NewLine);
        }
    }

    public void ShowMessage(string message)
    {
        consoleInterface.Write(message + Environment.NewLine);
    }
}
