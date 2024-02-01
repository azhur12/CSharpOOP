namespace Bankomat.Exceptions;

public class InsofficientFundsException : Exception
{
    public InsofficientFundsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InsofficientFundsException(string message)
        : base(message)
    {
    }

    public InsofficientFundsException()
    {
    }
}