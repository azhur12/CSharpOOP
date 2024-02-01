using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class TreeCommandHandler : BaseHandler
{
    public TreeCommandHandler(IHandler nextHandler, IHandler subHandler)
        : base(nextHandler, subHandler)
    {
    }

    public override ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException();
        if (command[0] == "tree")
        {
            if (SubHandler == null) throw new MyNullException();
            return SubHandler.Handle(command);
        }
        else
        {
            if (NextHandler == null) throw new MyNullException();
            return NextHandler.Handle(command);
        }
    }
}