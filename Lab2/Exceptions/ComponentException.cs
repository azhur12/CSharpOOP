using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ComponentException : Exception
{
    public ComponentException(string message)
        : base(message)
    {
    }

    public ComponentException()
    {
    }

    public ComponentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}