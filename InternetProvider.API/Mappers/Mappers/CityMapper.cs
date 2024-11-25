using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class CityMapper(ICity city) : IMapper<ICity, CityRequestDto, CityResponseDto>
{
    public CityResponseDto ToResponseDto(ICity oth)
    {
        return new CityResponseDto()
        {
            Id = oth.CityId,
            Name = oth.CityName,
        };
    }
    
    public ICity ToEntity(CityRequestDto oth)
    {
        city.CityName = oth.Name;
        
        return city;
    }
}