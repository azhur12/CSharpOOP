using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class MyNullException : Exception
{
    public MyNullException(string message)
        : base(message)
    {
    }

    public MyNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public MyNullException()
    {
    }
}