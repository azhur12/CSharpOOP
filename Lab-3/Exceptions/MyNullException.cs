using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MyNullException : Exception
{
    public MyNullException(string message)
        : base(message)
    {
    }

    public MyNullException()
    {
    }

    public MyNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}