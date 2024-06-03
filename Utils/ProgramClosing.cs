using AssemblyTest;

namespace Utils;

public static class ProgramClosing
{
    public static void ExitWithMessage(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
        Environment.Exit(0);
    }
}
