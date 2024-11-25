using System.Linq.Expressions;
using InternetProvider.Abstraction.Sort;

namespace InternetProvider.Infrastructure.Repositories.Extensions;

public static class QueryableExtensions
{
    public static IOrderedQueryable<T> ApplyInitialSort<T, TExpressionReturned>(
        this IQueryable<T> source, 
        Expression<Func<T, TExpressionReturned>> keySelector, 
        SortType sortType)
    {
        return sortType switch
        {
            SortType.Ascending => source.OrderBy(keySelector),
            SortType.Descending => source.OrderByDescending(keySelector),
            _ => throw new ArgumentException("Invalid sort type")
        };
    }
    
    public static IOrderedQueryable<T> ApplyThenBySort<T, TExpressionReturned>(
        this IOrderedQueryable<T> source, 
        Expression<Func<T, TExpressionReturned>> keySelector, 
        SortType sortType)
    {
        return sortType switch
        {
            SortType.Ascending => source.ThenBy(keySelector),
            SortType.Descending => source.ThenByDescending(keySelector),
            _ => throw new ArgumentException("Invalid sort type")
        };
    }
}