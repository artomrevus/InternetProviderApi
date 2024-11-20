using InternetProvider.Domain.Entities;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class LocationMappers
{
    public static LocationOutput ToDomainLocationOutput(this Location oth)
    {
        return new LocationOutput()
        {
            Id = oth.LocationId,
            LocationTypeName = oth.LocationType.LocationTypeName,
            CityName = oth.House.Street.City.CityName,
            StreetName = oth.House.Street.StreetName,
            HouseNumber = oth.House.HouseNumber,
            ApartmentNumber = oth.ApartmentNumber,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static Location ToInfrastructureLocation(this LocationInput oth)
    {
        return new Location()
        {
            LocationTypeId = oth.LocationTypeId,
            HouseId = oth.HouseId,
            ApartmentNumber = oth.ApartmentNumber,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}