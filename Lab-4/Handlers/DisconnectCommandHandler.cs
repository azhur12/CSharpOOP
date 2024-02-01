using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class DisconnectCommandHandler : BaseHandler
{
    public DisconnectCommandHandler(IHandler nextHandler, IHandler subHandler)
        : base(nextHandler, subHandler)
    {
    }

    public override ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException();
        if (command[0] == "disconnect")
        {
            return new Disconnect();
        }
        else
        {
            return NextHandler.Handle(command);
        }
    }
}