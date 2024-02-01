using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class Messenger : IRecipient
{
    public Messenger()
    {
    }

    public Message? Message { get; set; }

    public void Receive(Message message)
    {
        Message = message;
    }

    public void LogMessage()
    {
        Console.WriteLine("Messenger: " + Message?.Title + '\n' + Message?.Body + '\n');
    }
}