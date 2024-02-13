namespace GamesDataParser;

public class FileReader
{
    public string ReadFileContents(string? path)
    {
        VerifyInputPath(path);
        return File.ReadAllText(path!);
    }

    private static void VerifyInputPath(string? path)
    {
        if (path is null)
            throw new FileReaderException(FileReaderExceptionType.NullPath);
        if (path == string.Empty)
            throw new FileReaderException(FileReaderExceptionType.EmptyInput);
        if (!File.Exists(path))
            throw new FileReaderException(FileReaderExceptionType.FileNotFound);
    }
}
