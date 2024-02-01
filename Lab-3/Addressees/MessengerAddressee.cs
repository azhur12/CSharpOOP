using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : Addressee
{
    public MessengerAddressee(IRecipient messenger, Importance importance)
        : base(messenger, importance)
    {
    }
}