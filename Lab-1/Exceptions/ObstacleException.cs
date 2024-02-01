using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ObstacleException : Exception
{
    public ObstacleException(string message)
        : base(message) { }
    public ObstacleException() { }
    public ObstacleException(string message, Exception innerException)
        : base(message, innerException) { }
}