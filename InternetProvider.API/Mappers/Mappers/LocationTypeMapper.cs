using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class LocationTypeMapper(ILocationType locationType) : IMapper<ILocationType, LocationTypeRequestDto, LocationTypeResponseDto>
{
    public LocationTypeResponseDto ToResponseDto(ILocationType oth)
    {
        return new LocationTypeResponseDto()
        {
            Id = oth.LocationTypeId,
            Name = oth.LocationTypeName,
        };
    }

    public ILocationType ToEntity(LocationTypeRequestDto oth)
    {
        locationType.LocationTypeName = oth.Name;
        
        return locationType;
    }
}