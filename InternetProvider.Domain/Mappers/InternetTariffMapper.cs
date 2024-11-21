using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class InternetTariffMapper
{
    public static InternetTariffOutput ToDomainInternetTariffOutput(this InternetTariff oth)
    {
        return new InternetTariffOutput()
        {
            Id = oth.InternetTariffId,
            InternetTariffStatusName = oth.InternetTariffStatus.InternetTariffStatusName,
            LocationTypeName = oth.LocationType.LocationTypeName,
            Name = oth.Name,
            Price = oth.Price,
            InternetSpeedMbits = oth.InternetSpeedMbits,
            Description = oth.Description,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static InternetTariff ToInfrastructureInternetTariff(this InternetTariffInput oth)
    {
        return new InternetTariff()
        {
            InternetTariffStatusId = oth.InternetTariffStatusId,
            LocationTypeId = oth.LocationTypeId,
            Name = oth.Name,
            Price = oth.Price,
            InternetSpeedMbits = oth.InternetSpeedMbits,
            Description = oth.Description,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}