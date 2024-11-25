using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class HouseMapper(IHouse house) : IMapper<IHouse, HouseRequestDto, HouseResponseDto>
{
    public HouseResponseDto ToResponseDto(IHouse oth)
    {
        return new HouseResponseDto()
        {
            Id = oth.HouseId,
            CityName = oth.Street.City.CityName,
            StreetName = oth.Street.StreetName,
            HouseNumber = oth.HouseNumber,
        };
    }

    public IHouse ToEntity(HouseRequestDto oth)
    {
        house.StreetId = oth.StreetId;
        house.HouseNumber = oth.HouseNumber;
        
        return house;
    }
}