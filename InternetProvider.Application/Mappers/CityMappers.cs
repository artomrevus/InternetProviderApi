using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities;

namespace InternetProvider.Application.Mappers;

public static class CityMappers
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