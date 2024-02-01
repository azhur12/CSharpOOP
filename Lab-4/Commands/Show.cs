using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Show : ICommand
{
    public Show(string currentPath)
    {
        CurrentPath = currentPath;
    }

    private string CurrentPath { get; set; }
    public string Execute()
    {
        string fullPath = Path.GetFullPath(CurrentPath);
        string fileText = File.ReadAllText(fullPath);
        Console.Write(fileText);
        return fullPath;
    }
}