using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class LocationMapper(ILocation location) : IMapper<ILocation, LocationRequestDto, LocationResponseDto>
{
    public LocationResponseDto ToResponseDto(ILocation oth)
    {
        return new LocationResponseDto()
        {
            Id = oth.LocationId,
            LocationTypeName = oth.LocationType.LocationTypeName,
            CityName = oth.House.Street.City.CityName,
            StreetName = oth.House.Street.StreetName,
            HouseNumber = oth.House.HouseNumber,
            ApartmentNumber = oth.ApartmentNumber,
        };
    }

    public ILocation ToEntity(LocationRequestDto oth)
    {
        location.LocationTypeId = oth.LocationTypeId;
        location.HouseId = oth.HouseId;
        location.ApartmentNumber = oth.ApartmentNumber;
        
        return location;
    }
}