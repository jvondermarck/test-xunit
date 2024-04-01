using LoadManagementAppDomain;

namespace LoanManagementAppTests;

public class FileSystemFake : IFileSystem
{
    public Dictionary<string, string> Files { get; private set; } = new();

    public decimal GetInfoFromFile(string fileName)
    {
        return decimal.Parse(Files[fileName]);
    }

    public void SaveResult(string content, string fileName)
    {
        Files[fileName] = content;
    }
}
