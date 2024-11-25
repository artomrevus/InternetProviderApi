using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class InternetTariffStatusMapper(IInternetTariffStatus internetTariffStatus) : IMapper<IInternetTariffStatus, InternetTariffStatusRequestDto, InternetTariffStatusResponseDto>
{
    public InternetTariffStatusResponseDto ToResponseDto(IInternetTariffStatus oth)
    {
        return new InternetTariffStatusResponseDto()
        {
            Id = oth.InternetTariffStatusId,
            Name = oth.InternetTariffStatusName,
        };
    }

    public IInternetTariffStatus ToEntity(InternetTariffStatusRequestDto oth)
    {
        internetTariffStatus.InternetTariffStatusName = oth.Name;
        
        return internetTariffStatus;
    }
}