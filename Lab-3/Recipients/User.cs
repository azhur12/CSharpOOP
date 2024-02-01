using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class User : IRecipient
{
    public User()
    {
        Messages = new List<WrappedMessage>();
    }

    private IList<WrappedMessage>? Messages { get; init; }

    public bool IsMessageRead(int indexOfMessage)
    {
        return Messages is not null ? Messages[indexOfMessage].IsMarked : throw new MyNullException();
    }

    public Message? GetMessage(int indexOfMessage)
    {
        return Messages is not null ? Messages[indexOfMessage].Message : throw new MyNullException();
    }

    public void Receive(Message message)
    {
        Messages?.Add(new WrappedMessage(message));
    }

    public void MarkAsRead(Message message)
    {
        if (Messages is null) throw new MyNullException();
        foreach (WrappedMessage currentMessage in Messages)
        {
            if (currentMessage.Message is null) throw new MyNullException();
            if (!currentMessage.Message.Equals(message)) continue;
            if (currentMessage.IsMarked)
            {
                throw new InvalidStateException("Message has already read");
            }

            currentMessage.MarkMessage(true);
            break;
        }
    }
}