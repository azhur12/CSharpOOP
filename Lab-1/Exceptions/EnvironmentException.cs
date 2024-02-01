﻿using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class EnvironmentException : Exception
{
    public EnvironmentException(string message)
        : base(message) { }

    public EnvironmentException()
    {
    }

    public EnvironmentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}