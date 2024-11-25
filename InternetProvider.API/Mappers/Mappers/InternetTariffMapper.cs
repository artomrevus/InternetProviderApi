using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class InternetTariffMapper(IInternetTariff internetTariff) : IMapper<IInternetTariff, InternetTariffRequestDto, InternetTariffResponseDto>
{
    public InternetTariffResponseDto ToResponseDto(IInternetTariff oth)
    {
        return new InternetTariffResponseDto()
        {
            Id = oth.InternetTariffId,
            InternetTariffStatusName = oth.InternetTariffStatus.InternetTariffStatusName,
            LocationTypeName = oth.LocationType.LocationTypeName,
            Name = oth.Name,
            Price = oth.Price,
            InternetSpeedMbits = oth.InternetSpeedMbits,
            Description = oth.Description,
        };
    }

    public IInternetTariff ToEntity(InternetTariffRequestDto oth)
    {
        internetTariff.InternetTariffStatusId = oth.InternetTariffStatusId;
        internetTariff.LocationTypeId = oth.LocationTypeId;
        internetTariff.Name = oth.Name;
        internetTariff.Price = oth.Price;
        internetTariff.InternetSpeedMbits = oth.InternetSpeedMbits;
        internetTariff.Description = oth.Description;
        
        return internetTariff;
    }
}