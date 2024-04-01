namespace LoadManagementAppDomain;

public interface IFileSystem
{
    public void SaveResult(string content, string fileName);

    public decimal GetInfoFromFile(string fileName);
}
