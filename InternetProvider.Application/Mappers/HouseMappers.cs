using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities;

namespace InternetProvider.Application.Mappers;

public static class HouseMappers
{
    public static HouseResponseDto ToHouseResponseDto(this HouseOutput oth)
    {
        return new HouseResponseDto()
        {
            Id = oth.Id,
            CityName = oth.CityName,
            StreetName = oth.StreetName,
            HouseNumber = oth.HouseNumber,
        };
    }
    
    public static HouseInput ToDomainHouseInput(this HouseRequestDto oth)
    {
        return new HouseInput()
        {
            StreetId = oth.StreetId,
            HouseNumber = oth.HouseNumber,
        };
    }
}