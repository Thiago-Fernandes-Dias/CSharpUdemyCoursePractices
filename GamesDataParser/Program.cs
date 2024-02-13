using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace GamesDataParser;

internal static class Program
{
    private static void Main()
    {
        ExceptionsLogger exceptionsLogger = new();
        var fileFromUser = GetFileContentsFromUser();
        {
            try
            {
                var games = JsonSerializer.Deserialize<List<GameData>>(fileFromUser.Item1)!;
                if (games.Count != 0)
                {
                    Console.WriteLine("Loaded games are:");
                    foreach (var game in games)
                        Console.WriteLine($"{game.Title}, released in {game.ReleaseYear}, rating: {game.Rating}");
                }
                else
                    Console.WriteLine("No games found.");
                Console.WriteLine("Press any key to close...");
                Console.Read();
            }
            catch (JsonException ex)
            {
                PrintErrorMessageInRed(fileFromUser);
                exceptionsLogger.LogException(ex);
            }
            catch (Exception ex)
            {
                exceptionsLogger.LogException(ex);
            }
        }
    }

    private static void PrintErrorMessageInRed(( string fileContents, string fileName ) fileFromUser)
    {
        var originalConsoleFGColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        var erroMessage = $"JSON in the {fileFromUser.fileName} was not in a valid format. "
            + $"JSON body: {fileFromUser.fileContents}";
        Console.WriteLine(erroMessage);
        Console.ForegroundColor = originalConsoleFGColor;
        Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
    }

    private static (string, string) GetFileContentsFromUser()
    {
        FileReader fileReader = new();
        string fileContents;
        string? fileName;
        while (true)
        {
            try
            {
                Console.Write("Enter the name of the file you want to read: ");
                fileName = Console.ReadLine();
                fileContents = fileReader.ReadFileContents(fileName);
                break;
            }
            catch (FileReaderException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
        return (fileContents, fileName!);
    }
}