using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ConnectCommandHandler : BaseHandler
{
    public ConnectCommandHandler(IHandler nextHandler, IHandler subHandler)
        : base(nextHandler, subHandler)
    {
    }

    public override ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException();
        if (command[0] == "connect")
        {
            return new Connect(command[1]);
        }
        else
        {
            return NextHandler.Handle(command);
        }
    }
}