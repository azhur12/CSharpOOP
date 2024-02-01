using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class InvalidStateException : Exception
{
    public InvalidStateException(string message)
        : base(message)
    {
    }

    public InvalidStateException()
    {
    }

    public InvalidStateException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}