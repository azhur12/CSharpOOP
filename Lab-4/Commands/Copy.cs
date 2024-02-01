using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Copy : ICommand
{
    public Copy(string sPath, string dPath)
    {
        SourcePath = sPath;
        DestinationPath = dPath;
    }

    private string SourcePath { get; set; }
    private string DestinationPath { get; set; }
    public string Execute()
    {
        string fullSource = Path.GetFullPath(SourcePath);
        string fullDestination = Path.GetFullPath(DestinationPath);
        File.Copy(fullSource, fullDestination);
        return fullSource;
    }
}