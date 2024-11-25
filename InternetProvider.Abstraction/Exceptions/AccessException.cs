namespace InternetProvider.Abstraction.Exceptions;

public class AccessException : System.Exception
{
    public AccessException() 
        : base("Access error.") 
    { 
    }

    public AccessException(string message)
        : base(message)
    {
    }
}