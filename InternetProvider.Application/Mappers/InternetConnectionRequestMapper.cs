using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class InternetConnectionRequestMapper
{
    public static InternetConnectionRequestResponseDto ToInternetConnectionRequestResponseDto(this InternetConnectionRequestOutput oth)
    {
        return new InternetConnectionRequestResponseDto()
        {
            ClientPhoneNumber = oth.ClientPhoneNumber,
            ClientEmail = oth.ClientEmail,
            InternetTariffName = oth.InternetTariffName,
            InternetTariffPrice = oth.InternetTariffPrice,
            InternetTariffSpeedMbits = oth.InternetTariffSpeedMbits,
            InternetConnectionRequestStatusName = oth.InternetConnectionRequestStatusName,
            Number = oth.Number,
            RequestDate = oth.RequestDate,
        };
    }
    
    public static InternetConnectionRequestInput ToDomainInternetConnectionRequestInput(this InternetConnectionRequestRequestDto oth)
    {
        return new InternetConnectionRequestInput()
        {
            ClientId = oth.ClientId,
            InternetTariffId = oth.InternetTariffId,
            InternetConnectionRequestStatusId = oth.InternetConnectionRequestStatusId,
            Number = oth.Number,
        };
    }
}