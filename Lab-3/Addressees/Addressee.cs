using System;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class Addressee : IAddressee
{
    protected Addressee(IRecipient recipient, Importance importanceFilter)
    {
        ImportanceFilter = importanceFilter;
        Recipient = recipient;
    }

    protected Message? Message { get; set; }
    private Importance? ImportanceFilter { get; set; }
    private IRecipient Recipient { get; init; }
    public Importance? GetImportanceLevel()
    {
        return ImportanceFilter;
    }

    public void Receive(Message message)
    {
        Message = message;
        Console.WriteLine("New message with Title: " + Message.Title + " received.");
    }

    public void LogMessage()
    {
        Console.WriteLine(Message?.Title + '\n' + Message?.Body + '\n');
    }

    public void Send()
    {
        if (Message != null) Recipient.Receive(Message);
    }
}