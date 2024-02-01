namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message
{
    public Message(string? title, string? body, Importance importance)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importance;
    }

    public string? Title { get; private set; }
    public string? Body { get; private set; }
    public Importance? ImportanceLevel { get; private set; }
}