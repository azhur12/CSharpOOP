using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class Display : IRecipient
{
    public Message? Message { get; set; }
    private DisplayDriver? DisplayDriver { get; set; }

    public void Show(ConsoleColor color)
    {
        DisplayDriver.ClearOutput();
        DisplayDriver?.SetColor(color);
        if (Message?.Title is null) throw new MyNullException();
        DisplayDriver?.WriteText(Message.Title);
        if (Message?.Body is null) throw new MyNullException();
        DisplayDriver?.WriteText(Message.Body);
    }

    public void WriteToFile(string filePath)
    {
        if (Message?.Title is null) throw new MyNullException();
        File.WriteAllText(filePath, Message.Title);
        if (Message?.Body is null) throw new MyNullException();
        File.WriteAllText(filePath, Message.Body);
    }

    public void Receive(Message message)
    {
        Message = message;
    }
}