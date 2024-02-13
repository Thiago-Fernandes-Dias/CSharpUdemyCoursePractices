using System.Runtime.Serialization;

namespace GamesDataParser;

internal class FileReaderException(FileReaderExceptionType type) : Exception(GetMessage(type))
{
    private static string GetMessage(FileReaderExceptionType type)
    {
        return type switch
        {
            FileReaderExceptionType.FileNotFound => "File not found",
            FileReaderExceptionType.EmptyInput => "File name cannot be empty",
            FileReaderExceptionType.NullPath => "File name cannot be null.",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}
