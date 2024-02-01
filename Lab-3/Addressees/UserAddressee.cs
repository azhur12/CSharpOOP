using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddressee : Addressee
{
    public UserAddressee(IRecipient user, Importance importanceFilter)
        : base(user, importanceFilter)
    {
    }
}