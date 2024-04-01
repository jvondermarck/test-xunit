namespace LoadManagementAppDomain;

public class FileSystem : IFileSystem
{
    public decimal GetInfoFromFile(string fileName)
    {
        return decimal.Parse(File.ReadAllText(fileName));
    }

    public void SaveResult(string content, string fileName)
    {
        string outputDirectory = "LoanPaymentsCSV";
        Directory.CreateDirectory(outputDirectory);
        fileName = Path.Combine(outputDirectory, fileName);

        File.AppendAllText(fileName, content);
    }
}