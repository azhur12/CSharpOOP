using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.SubHandlers;

public abstract class BaseSubHandler : IHandler
{
    protected BaseSubHandler(IHandler nextHandler)
    {
        NextHandler = nextHandler;
    }

    public IHandler NextHandler { get; set; }
    public abstract ICommand Handle(string[] command);
}