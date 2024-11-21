using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class CityMapper
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