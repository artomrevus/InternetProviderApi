using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class InternetTariffStatusMapper
{
    public static InternetTariffStatusResponseDto ToInternetTariffStatusResponseDto(this InternetTariffStatusOutput oth)
    {
        return new InternetTariffStatusResponseDto()
        {
            Id = oth.Id,
            Name = oth.Name,
        };
    }
    
    public static InternetTariffStatusInput ToDomainInternetTariffStatusInput(this InternetTariffStatusRequestDto oth)
    {
        return new InternetTariffStatusInput()
        {
            Name = oth.Name,
        };
    }
}