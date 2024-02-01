using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddressee : Addressee
{
    public DisplayAddressee(IRecipient display, Importance importance)
        : base(display, importance)
    {
    }
}