using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities;

namespace InternetProvider.Application.Mappers;

public static class LocationMappers
{
    public static LocationResponseDto ToLocationResponseDto(this LocationOutput oth)
    {
        return new LocationResponseDto()
        {
            Id = oth.Id,
            LocationTypeName = oth.LocationTypeName,
            CityName = oth.CityName,
            StreetName = oth.StreetName,
            HouseNumber = oth.HouseNumber,
            ApartmentNumber = oth.ApartmentNumber,
        };
    }
    
    public static LocationInput ToDomainLocationInput(this LocationRequestDto oth)
    {
        return new LocationInput()
        {
            LocationTypeId = oth.LocationTypeId,
            HouseId = oth.HouseId,
            ApartmentNumber = oth.ApartmentNumber,
        };
    }
}