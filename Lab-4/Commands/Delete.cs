using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Delete : ICommand
{
    public Delete(string path)
    {
        CurrentPath = path;
    }

    private string CurrentPath { get; set; }
    public string Execute()
    {
        CurrentPath = Path.GetFullPath(CurrentPath);
        File.Delete(CurrentPath);
        string? fullName = Directory.GetParent(CurrentPath)?.FullName;
        if (fullName != null) return fullName;
        else return string.Empty;
    }
}