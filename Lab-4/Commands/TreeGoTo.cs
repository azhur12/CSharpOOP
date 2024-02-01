using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoTo : ICommand
{
    public TreeGoTo(string path)
    {
        CurrentPath = path;
    }

    private string CurrentPath { get; set; }
    public string Execute()
    {
        string destinationPath = Path.GetFullPath(CurrentPath);
        return destinationPath;
    }
}