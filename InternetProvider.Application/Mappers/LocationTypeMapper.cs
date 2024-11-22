using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class LocationTypeMapper
{
    public static LocationTypeResponseDto ToLocationTypeResponseDto(this LocationTypeOutput oth)
    {
        return new LocationTypeResponseDto()
        {
            Id = oth.Id,
            Name = oth.Name,
        };
    }
    
    public static LocationTypeInput ToDomainLocationTypeInput(this LocationTypeRequestDto oth)
    {
        return new LocationTypeInput()
        {
            Name = oth.Name,
        };
    }
}