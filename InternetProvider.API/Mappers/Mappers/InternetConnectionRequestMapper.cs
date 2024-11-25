using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class InternetConnectionRequestMapper(IInternetConnectionRequest internetConnectionRequest) : IMapper<IInternetConnectionRequest, InternetConnectionRequestRequestDto, InternetConnectionRequestResponseDto>
{
    public InternetConnectionRequestResponseDto ToResponseDto(IInternetConnectionRequest oth)
    {
        return new InternetConnectionRequestResponseDto()
        {
            Id = oth.InternetConnectionRequestId,
            ClientPhoneNumber = oth.Client.PhoneNumber,
            ClientEmail = oth.Client.Email,
            InternetTariffName = oth.InternetTariff.Name,
            InternetTariffPrice = oth.InternetTariff.Price,
            InternetTariffSpeedMbits = oth.InternetTariff.InternetSpeedMbits,
            InternetConnectionRequestStatusName = oth.InternetConnectionRequestStatus.InternetConnectionRequestStatusName,
            Number = oth.Number,
            RequestDate = oth.RequestDate,
        };
    }

    public IInternetConnectionRequest ToEntity(InternetConnectionRequestRequestDto oth)
    {
        internetConnectionRequest.ClientId = oth.ClientId;
        internetConnectionRequest.InternetTariffId = oth.InternetTariffId;
        internetConnectionRequest.InternetConnectionRequestStatusId = oth.InternetConnectionRequestStatusId;
        internetConnectionRequest.Number = oth.Number;
        
        return internetConnectionRequest;
    }
}