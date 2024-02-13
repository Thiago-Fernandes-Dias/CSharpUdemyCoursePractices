using Utils.DataAccess;
using Utils.DataAccess.StringsRepository;

Names names = new();
var path = new NamesFilePathBuilder().BuildFilePath();
StringsFromTextFileRepository repo = new(path);

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    var stringsFromFile = repo.Read();
    names.AddNames(stringsFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exist.");
    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");
    Console.WriteLine("Saving names to the file.");
    repo.Write(names.All);
}
Console.WriteLine(NamesFormatter.Format(names.All));
Console.ReadLine();
