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
}