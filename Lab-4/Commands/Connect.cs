namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Connect : ICommand
{
    public Connect(string curPath)
    {
        CurrentPath = curPath;
    }

    private string CurrentPath { get; set; }
    public string Execute()
    {
        return CurrentPath;
    }
}