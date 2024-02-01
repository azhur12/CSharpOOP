using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.SubHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class HandleSystem
{
    public HandleSystem(string currentPath)
    {
        CurrentPath = currentPath;
        var renameHandler = new RenameHandler(new EmptyHandler());
        var deleteHandler = new DeleteHandler(renameHandler);
        var copyHandler = new CopyHandler(deleteHandler);
        var moveHandler = new MoveHandler(copyHandler);
        var showHandler = new ShowHandler(moveHandler);

        var gotoHandler = new GotoHandler(new EmptyHandler());
        ListHandler = new ListHandler(gotoHandler, CurrentPath);

        var treeCommandHandler = new TreeCommandHandler(new EmptyHandler(), ListHandler);
        var fileCommandHandler = new FileCommandHandler(treeCommandHandler, showHandler);
        var disconnectCommandHandler = new DisconnectCommandHandler(fileCommandHandler, new EmptyHandler());
        ConnectCommandHandler = new ConnectCommandHandler(disconnectCommandHandler, new EmptyHandler());
    }

    private ConnectCommandHandler ConnectCommandHandler { get; set; }
    private ListHandler ListHandler { get; set; }
    private string CurrentPath { get; set; }

    public string Request(string commandLine)
    {
        if (commandLine == null) throw new MyNullException("CommandLine is null");
        string[] command = commandLine.Split(" ");
        ICommand commandShell = ConnectCommandHandler.Handle(command);
        CurrentPath = commandShell.Execute();
        ListHandler.SetCurrentPath(CurrentPath);
        return CurrentPath;
    }
}