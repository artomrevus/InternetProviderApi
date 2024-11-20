using InternetProvider.Domain.Entities;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class LocationTypeMappers
{
    public static LocationTypeOutput ToDomainLocationTypeOutput(this LocationType oth)
    {
        return new LocationTypeOutput()
        {
            Id = oth.LocationTypeId,
            Name = oth.LocationTypeName,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static LocationType ToInfrastructureLocationType(this LocationTypeInput oth)
    {
        return new LocationType()
        {
            LocationTypeName = oth.Name,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}