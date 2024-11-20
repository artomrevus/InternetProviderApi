namespace InternetProvider.Infrastructure.Exceptions;

public class RepositoryException : Exception
{
    public RepositoryException() 
        : base("Something went wrong with the repository.") 
    { 
    }

    public RepositoryException(string message)
        : base(message)
    {
    }
    
    public static void ThrowIfNull(object? obj, string message)
    {
        if (obj is null)
        {
            throw new RepositoryException(message);
        }
    }
}