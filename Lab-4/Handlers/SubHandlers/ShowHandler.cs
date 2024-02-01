using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.SubHandlers;

public class ShowHandler : BaseSubHandler
{
    public ShowHandler(IHandler nextHandler)
        : base(nextHandler)
    {
    }

    public override ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException();
        if (command[1] == "show")
        {
            if (command[4] == "console")
            {
                return new Show(command[2]);
            }
            else
            {
                throw new MyNullException("There is no other mode but console");
            }
        }
        else
        {
            return NextHandler.Handle(command);
        }
    }
}