namespace InternetProvider.Application.Exception;

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