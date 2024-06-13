namespace Utils;

public interface IUserInterface
{
    public void ShowMessage(string message);

    public int ReadInteger(string message);

    public string ReadString(string message);

    public int ReadInteger(string message, Func<int, bool> validationDel);

    public string ReadString(string message, Func<string, bool> validationDel);
}