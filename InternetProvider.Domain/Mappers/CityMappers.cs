using InternetProvider.Domain.Entities;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class CityMappers 
{
    public static CityOutput ToDomainCityOutput(this City oth)
    {
        return new CityOutput()
        {
            Id = oth.CityId,
            Name = oth.CityName,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static City ToInfrastructureCity(this CityInput oth)
    {
        return new City()
        {
           CityName = oth.Name,
           CreateDateTime = oth.CreateDateTime,
           UpdateDateTime = oth.UpdateDateTime,
        };
    }
}