namespace Bankomat.Exceptions;

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidArgumentException(string message)
        : base(message)
    {
    }

    public InvalidArgumentException()
    {
    }
}