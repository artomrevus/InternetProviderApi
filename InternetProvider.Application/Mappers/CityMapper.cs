using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class CityMapper
{
    public static CityResponseDto ToCityResponseDto(this CityOutput oth)
    {
        return new CityResponseDto()
        {
            Id = oth.Id,
            Name = oth.Name,
        };
    }
    
    public static CityInput ToDomainCityInput(this CityRequestDto oth)
    {
        return new CityInput()
        {
            Name = oth.Name,
        };
    }
}