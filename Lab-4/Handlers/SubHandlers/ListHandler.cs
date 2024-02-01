using System.IO;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.SubHandlers;

public class ListHandler : BaseSubHandler
{
    public ListHandler(IHandler nextHandler, string curPath)
        : base(nextHandler)
    {
        CurrPath = curPath;
        DepthHandler = new DepthHandler(CurrPath, new EmptyHandler());
    }

    private DepthHandler DepthHandler { get; set; }
    private string CurrPath { get; set; }

    public override ICommand Handle(string[] command)
    {
        if (command == null) throw new MyNullException();
        if (command[1] == "list")
        {
            DepthHandler.SetCommand(new List(CurrPath));
            return DepthHandler.Handle(command);
        }
        else
        {
            if (NextHandler == null) throw new MyNullException();
            return NextHandler.Handle(command);
        }
    }

    public void SetCurrentPath(string path)
    {
        CurrPath = Path.GetFullPath(path);
    }
}