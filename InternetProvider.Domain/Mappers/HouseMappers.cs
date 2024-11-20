using InternetProvider.Domain.Entities;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class HouseMappers
{
    public static HouseOutput ToDomainHouseOutput(this House oth)
    {
        return new HouseOutput()
        {
            Id = oth.HouseId,
            CityName = oth.Street.City.CityName,
            StreetName = oth.Street.StreetName,
            HouseNumber = oth.HouseNumber,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static House ToInfrastructureHouse(this HouseInput oth)
    {
        return new House()
        {
            StreetId = oth.StreetId,
            HouseNumber = oth.HouseNumber,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}