namespace LoadManagementAppDomain;

public class ScheduleGenerator
{
    private IFileSystem _fileSystemFake { get; }
    private IClock _clock { get; }
    public ScheduleGenerator(IFileSystem fileSystemFake, IClock clock)
    {
        _fileSystemFake = fileSystemFake;
        _clock = clock;
    }


}
