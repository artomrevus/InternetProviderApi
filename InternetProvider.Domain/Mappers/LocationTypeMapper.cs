using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class LocationTypeMapper
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