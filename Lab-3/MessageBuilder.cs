namespace Itmo.ObjectOrientedProgramming.Lab3;

public class MessageBuilder
{
    private string? Title { get; set; }
    private string? Body { get; set; }
    private Importance Importance { get; set; }

    public MessageBuilder WithTitle(string title)
    {
        Title = title;
        return this;
    }

    public MessageBuilder WithBody(string body)
    {
        Body = body;
        return this;
    }

    public MessageBuilder WithImportance(Importance importance)
    {
        Importance = importance;
        return this;
    }

    public Message Build()
    {
        return new Message(Title, Body, Importance);
    }
}