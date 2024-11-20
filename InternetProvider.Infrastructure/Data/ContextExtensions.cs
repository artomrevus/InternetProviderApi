using InternetProvider.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Data;

public static class DbContextExtensions
{
    public static async Task SaveRepositoryChangesAsync(this DbContext context)
    {
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            throw new RepositoryException($"Error while saving changes: {e.InnerException?.Message}");
        }
    }
}