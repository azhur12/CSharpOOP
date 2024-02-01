using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Move : ICommand
{
    public Move(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    private string SourcePath { get; set; }
    private string DestinationPath { get; set; }
    public string Execute()
    {
        string fullSource = Path.GetFullPath(SourcePath);
        string fullDestination = Path.GetFullPath(DestinationPath);
        File.Move(fullSource, fullDestination);
        return fullSource;
    }
}