using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class StreetMapper(IStreet street) : IMapper<IStreet, StreetRequestDto, StreetResponseDto>
{
    public StreetResponseDto ToResponseDto(IStreet oth)
    {
        return new StreetResponseDto()
        {
            Id = oth.StreetId,
            CityName = oth.City.CityName,
            StreetName = oth.StreetName,
        };
    }

    public IStreet ToEntity(StreetRequestDto oth)
    {
        street.CityId = oth.CityId;
        street.StreetName = oth.Name;
        
        return street;
    }
}