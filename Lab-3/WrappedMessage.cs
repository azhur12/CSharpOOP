namespace Itmo.ObjectOrientedProgramming.Lab3;

public class WrappedMessage
{
    public WrappedMessage(Message message)
    {
        Message = message;
    }

    public string? Title => Message?.Title;
    public string? Body => Message?.Body;
    public Importance? ImportanceLevel => Message?.ImportanceLevel;

    public bool IsMarked { get; private set; }
    public Message? Message { get; set; }

    public void MarkMessage(bool mark)
    {
        IsMarked = mark;
    }
}