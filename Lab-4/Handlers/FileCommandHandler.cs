using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileCommandHandler : BaseHandler
{
    public FileCommandHandler(IHandler nextHandler, IHandler subHandler)
        : base(nextHandler, subHandler)
    {
    }

    public override ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException("Command is null");
        if (command[0] == "file")
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