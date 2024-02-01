namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeProxy : IAddressee
{
    public AddresseeProxy(IAddressee addressee)
    {
        Addressee = addressee;
    }

    private IAddressee? Addressee { get; init; }

    public Importance? GetImportanceLevel()
    {
        return Addressee?.GetImportanceLevel();
    }

    public void Receive(Message message)
    {
        if (Addressee?.GetImportanceLevel() >= message?.ImportanceLevel)
        {
            Addressee.Receive(message);
        }
    }

    public void LogMessage()
    {
        Addressee?.LogMessage();
    }

    public void Send()
    {
        Addressee?.Send();
    }
}