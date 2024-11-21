using InternetProvider.Infrastructure.Exceptions;

namespace InternetProvider.Infrastructure.Repositories.Extensions;

public static class ConvertRepositoryExtensions
{
    public static int ToInt(this object value)
    {
        if (value is null)
        {
            throw new RepositoryException("Cannot convert null to int.");
        }

        if (value is System.Text.Json.JsonElement jsonElement)
        {
            try
            {
                return jsonElement.GetInt32();
            }
            catch (Exception)
            {
                throw new RepositoryException($"Cannot convert {jsonElement} to int");
            }
        }
        
        if (value is IConvertible)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                throw new RepositoryException($"Failed to convert {value} to int.");
            }
        }

        throw new RepositoryException($"Cannot convert {value} to int. Value must be convertible to int or JsonElement.");
    }
    
    public static decimal ToDecimal(this object value)
    {
        if (value is null)
        {
            throw new RepositoryException("Cannot convert null to decimal.");
        }

        if (value is System.Text.Json.JsonElement jsonElement)
        {
            try
            {
                return jsonElement.GetDecimal();
            }
            catch (Exception)
            {
                throw new RepositoryException($"Cannot convert {jsonElement} to decimal");
            }
        }
        
        if (value is IConvertible)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception)
            {
                throw new RepositoryException($"Failed to convert {value} to decimal.");
            }
        }

        throw new RepositoryException($"Cannot convert {value} to decimal. Value must be convertible to decimal or JsonElement.");
    }
    
    public static DateOnly ToDateOnly(this object value)
    {
        if (value is null)
        {
            throw new RepositoryException("Cannot convert null to dateonly type.");
        }

        if (value is System.Text.Json.JsonElement jsonElement)
        {
            try
            {
                return DateOnly.FromDateTime(jsonElement.GetDateTime());
            }
            catch (Exception)
            {
                throw new RepositoryException($"Cannot convert {jsonElement} to dateonly.");
            }
        }
        
        if (value is IConvertible)
        {
            try
            {
                return DateOnly.FromDateTime(Convert.ToDateTime(value));
            }
            catch (Exception)
            {
                throw new RepositoryException($"Failed to convert {value} to dateonly.");
            }
        }

        throw new RepositoryException($"Cannot convert {value} to dateonly. Value must be convertible to dateonly or JsonElement.");
    }
    
    public static string ToStr(this object value)
    {
        if (value is null)
        {
            throw new RepositoryException("Cannot convert null to string.");
        }

        if (value is System.Text.Json.JsonElement jsonElement)
        {
            try
            {
                return jsonElement.GetString() ?? string.Empty;
            }
            catch (Exception)
            {
                throw new RepositoryException($"Cannot convert {jsonElement} to string");
            }
        }
        
        if (value is IConvertible)
        {
            try
            {
                return Convert.ToString(value) ?? string.Empty;
            }
            catch (Exception)
            {
                throw new RepositoryException($"Failed to convert {value} to string.");
            }
        }

        throw new RepositoryException($"Cannot convert {value} to string. Value must be convertible to string or JsonElement.");
    }
}