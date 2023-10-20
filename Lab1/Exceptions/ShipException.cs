using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ShipException : Exception
{
    public ShipException(string message)
        : base(message) { }

    public ShipException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ShipException()
    {
    }
}