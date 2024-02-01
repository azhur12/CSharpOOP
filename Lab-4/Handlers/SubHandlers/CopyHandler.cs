using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.SubHandlers;

public class CopyHandler : BaseSubHandler
{
    public CopyHandler(IHandler nextHandler)
        : base(nextHandler)
    {
    }

    public override ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException();
        if (command[1] == "copy")
        {
            return new Copy(command[2], command[3]);
        }
        else
        {
            return NextHandler.Handle(command);
        }
    }
}