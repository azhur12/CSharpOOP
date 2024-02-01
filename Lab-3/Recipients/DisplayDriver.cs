using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class DisplayDriver
{
    private ConsoleColor Color { get; set; }
    public static void ClearOutput()
    {
        Console.Clear();
    }

    public void SetColor(ConsoleColor color)
    {
        Color = color;
    }

    public void WriteText(string text)
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}