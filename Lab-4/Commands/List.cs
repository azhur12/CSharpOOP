using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class List : ICommand
{
    public List(string currentPath)
    {
        CurrentPath = currentPath;
    }

    private string CurrentPath { get; set; }
    private int Depth { get; set; }

    public void SetDepth(int depth)
    {
        Depth = depth;
    }

    public string Execute()
    {
        PrintList(CurrentPath, Depth, 0);
        return " ";
    }

    public void PrintList(string path, int depth = 0, int needTabs = 0)
    {
        string[] dirs = Directory.GetDirectories(path);
        for (int i = 0; i < dirs.Length; i++)
        {
            if (depth > 0)
            {
                string tab = string.Empty;
                for (int j = 0; j < needTabs; j++)
                {
                    tab += " ";
                }

                var directory = new DirectoryInfo(Path.GetFullPath(dirs[i]));
                Console.WriteLine(tab + directory.Name);
                PrintList(Path.GetFullPath(dirs[i]), --depth, ++needTabs);
            }
            else
            {
                string tab = string.Empty;
                for (int j = 0; j < needTabs; j++)
                {
                    tab += " ";
                }

                Console.WriteLine(tab + dirs[i]);
            }
        }
    }
}