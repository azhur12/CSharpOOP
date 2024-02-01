using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string? Name { get; private set; }
    public IAddressee? Addressee { get; private set; }
    public Message? Message { get; private set; }

    public void Receive(Message message)
    {
        Message = message;
    }

    public void Send()
    {
        if (Message != null) Addressee?.Receive(Message);
    }
}