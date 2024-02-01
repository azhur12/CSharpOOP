using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public abstract class BaseHandler : IHandler
{
    protected BaseHandler(IHandler nextHandler, IHandler subHandler)
    {
        NextHandler = nextHandler;
        SubHandler = subHandler;
    }

    public IHandler NextHandler { get; set; }
    public IHandler SubHandler { get; set; }
    public abstract ICommand Handle(string[] command);
}