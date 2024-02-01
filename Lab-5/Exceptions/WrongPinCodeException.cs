namespace Bankomat.Exceptions;

public class WrongPinCodeException : Exception
{
    public WrongPinCodeException(string message)
        : base(message)
    {
    }

    public WrongPinCodeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongPinCodeException()
    {
    }
}