using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class StreetMapper
{
    public static StreetResponseDto ToStreetResponseDto(this StreetOutput oth)
    {
        return new StreetResponseDto()
        {
            Id = oth.Id,
            CityName = oth.CityName,
            StreetName = oth.StreetName,
        };
    }
    
    public static StreetInput ToDomainStreetInput(this StreetRequestDto oth)
    {
        return new StreetInput()
        {
            Name = oth.Name,
            CityId = oth.CityId,
        };
    }
}