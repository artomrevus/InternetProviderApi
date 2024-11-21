using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class InternetTariffMapper
{
    public static InternetTariffResponseDto ToInternetTariffResponseDto(this InternetTariffOutput oth)
    {
        return new InternetTariffResponseDto()
        {
            Id = oth.Id,
            InternetTariffStatusName = oth.InternetTariffStatusName,
            LocationTypeName = oth.LocationTypeName,
            Name = oth.Name,
            Price = oth.Price,
            InternetSpeedMbits = oth.InternetSpeedMbits,
            Description = oth.Description,
        };
    }
    
    public static InternetTariffInput ToDomainInternetTariffInput(this InternetTariffRequestDto oth)
    {
        return new InternetTariffInput()
        {
            InternetTariffStatusId = oth.InternetTariffStatusId,
            LocationTypeId = oth.LocationTypeId,
            Name = oth.Name,
            Price = oth.Price,
            InternetSpeedMbits = oth.InternetSpeedMbits,
            Description = oth.Description,
        };
    }
}