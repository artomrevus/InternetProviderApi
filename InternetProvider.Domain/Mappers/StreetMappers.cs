using InternetProvider.Domain.Entities;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class StreetMappers
{
    public static StreetOutput ToDomainStreetOutput(this Street oth)
    {
        return new StreetOutput()
        {
            Id = oth.StreetId,
            StreetName = oth.StreetName,
            CityName = oth.City.CityName,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static Street ToInfrastructureStreet(this StreetInput oth)
    {
        return new Street()
        {
            CityId = oth.CityId,
            StreetName = oth.Name,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}