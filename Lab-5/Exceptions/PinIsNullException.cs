namespace Bankomat.Exceptions;

public class PinIsNullException : Exception
{
    public PinIsNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public PinIsNullException(string message)
        : base(message)
    {
    }

    public PinIsNullException()
    {
    }
}