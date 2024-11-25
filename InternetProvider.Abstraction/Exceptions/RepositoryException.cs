namespace InternetProvider.Abstraction.Exceptions;

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