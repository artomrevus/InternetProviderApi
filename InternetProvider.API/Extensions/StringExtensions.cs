using System.Text.Json;

namespace InternetProvider.API.Extensions;

public static class StringExtensions
{
    public static Dictionary<TKey, TValue>? FromJsonToDictionary<TKey, TValue>(this string? str) where TKey : notnull
    {
        return JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(str ?? "{}");
    }
}