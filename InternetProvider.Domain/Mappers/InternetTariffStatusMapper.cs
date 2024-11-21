using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class InternetTariffStatusMapper
{
    public static InternetTariffStatusOutput ToDomainInternetTariffStatusOutput(this InternetTariffStatus oth)
    {
        return new InternetTariffStatusOutput()
        {
            Id = oth.InternetTariffStatusId,
            Name = oth.InternetTariffStatusName,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static InternetTariffStatus ToInfrastructureInternetTariffStatus(this InternetTariffStatusInput oth)
    {
        return new InternetTariffStatus()
        {
            InternetTariffStatusName = oth.Name,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}