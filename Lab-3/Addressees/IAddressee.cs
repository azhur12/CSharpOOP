namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public interface IAddressee
{
    public Importance? GetImportanceLevel();
    public void Receive(Message message);
    public void LogMessage();
    public void Send();
}