using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class InternetConnectionRequestMapper
{
    public static InternetConnectionRequestOutput ToDomainInternetConnectionRequestOutput(this InternetConnectionRequest oth)
    {
        return new InternetConnectionRequestOutput()
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
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static InternetConnectionRequest ToInfrastructureInternetConnectionRequest(this InternetConnectionRequestInput oth)
    {
        return new InternetConnectionRequest()
        {
            ClientId = oth.ClientId,
            InternetTariffId = oth.InternetTariffId,
            InternetConnectionRequestStatusId = oth.InternetConnectionRequestStatusId,
            Number = oth.Number,
            RequestDate = oth.RequestDate,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}