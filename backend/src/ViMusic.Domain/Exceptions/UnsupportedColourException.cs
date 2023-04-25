namespace ViMusic.Domain.Exceptions;

public class UnsupportedException : Exception
{
    public UnsupportedException(string message)
        : base($"Exeption \"{message}\" is unsupported.")
    {
    }

    public UnsupportedException() : base()
    {
    }

    public UnsupportedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
