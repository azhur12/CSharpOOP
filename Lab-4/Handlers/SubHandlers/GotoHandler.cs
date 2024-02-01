using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.SubHandlers;

public class GotoHandler : BaseSubHandler
{
    public GotoHandler(IHandler nextHandler)
        : base(nextHandler)
    {
    }

    public override ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException();
        if (command[1] == "goto")
        {
            return new TreeGoTo(command[2]);
        }
        else
        {
            return NextHandler.Handle(command);
        }
    }
}