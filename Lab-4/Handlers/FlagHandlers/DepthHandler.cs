using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

public class DepthHandler : IHandler
{
    public DepthHandler(string currentPath, IHandler nextHandler)
    {
        CurrentPath = currentPath;
        NextHandler = nextHandler;
    }

    private string CurrentPath { get; set; }
    private IHandler NextHandler { get; set; }
    private List? Command { get; set; }

    public void SetCommand(List command)
    {
        Command = command;
    }

    public ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException();
        if (command.Length > 2 && command[2] == "-d")
        {
            if (Command == null) throw new MyNullException("Command is null, please set Command");
            Command.SetDepth(int.Parse(command[3], null));
            if (NextHandler.GetType() == typeof(EmptyHandler))
            {
                return Command;
            }
        }

        return NextHandler.Handle(command);
    }
}