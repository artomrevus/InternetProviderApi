using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class InternetConnectionRequestStatusMapper
{
    public static InternetConnectionRequestStatusOutput ToDomainInternetConnectionRequestStatusOutput(this InternetConnectionRequestStatus oth)
    {
        return new InternetConnectionRequestStatusOutput()
        {
            Id = oth.InternetConnectionRequestStatusId,
            Name = oth.InternetConnectionRequestStatusName,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static InternetConnectionRequestStatus ToInfrastructureInternetConnectionRequestStatus(this InternetConnectionRequestStatusInput oth)
    {
        return new InternetConnectionRequestStatus()
        {
            InternetConnectionRequestStatusName = oth.Name,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}