using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Rename : ICommand
{
    public Rename(string currentPath, string newName)
    {
        CurrentPath = currentPath;
        NewName = newName;
    }

    private string CurrentPath { get; set; }
    private string NewName { get; set; }
    public string Execute()
    {
        string fullName = Path.GetFullPath(CurrentPath);
        File.Move(fullName, Path.GetFullPath(NewName));
        return fullName;
    }
}