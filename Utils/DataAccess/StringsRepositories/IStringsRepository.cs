namespace Utils.DataAccess.StringsRepository;

public interface IStringsRepository
{
    List<string> Read();
    void Write(List<string> strings);
}