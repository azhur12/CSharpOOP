using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class EmptyHandler : IHandler
{
    public ICommand Handle(string[] command)
    {
        throw new MyNullException("No one can handle this request");
    }
}