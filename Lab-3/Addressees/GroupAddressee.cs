using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : IAddressee
{
    public GroupAddressee(Importance importanceFilter)
    {
        Addressees = new List<Addressee>();
        ImportanceFilter = importanceFilter;
    }

    public IList<Addressee>? Addressees { get; private init; }
    private Importance? ImportanceFilter { get; set; }
    public Importance? GetImportanceLevel()
    {
        return ImportanceFilter;
    }

    public void AddAddressee(Addressee addressee)
    {
        Addressees?.Add(addressee);
    }

    public void Receive(Message message)
    {
        if (Addressees is null) throw new MyNullException();
        foreach (Addressee variableAddressee in Addressees)
        {
            variableAddressee.Receive(message);
        }
    }

    public void LogMessage()
    {
        if (Addressees is null) throw new MyNullException();
        foreach (Addressee variableAddressee in Addressees)
        {
            variableAddressee.LogMessage();
        }
    }

    public void Send()
    {
        if (Addressees is null) throw new MyNullException();
        foreach (Addressee variableAddressee in Addressees)
        {
            variableAddressee.Send();
        }
    }
}