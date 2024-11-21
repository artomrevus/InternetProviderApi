using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class ClientStatusMapper
{
    public static ClientStatusOutput ToDomainClientStatusOutput(this ClientStatus oth)
    {
        return new ClientStatusOutput()
        {
            Id = oth.ClientStatusId,
            Name = oth.ClientStatusName,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static ClientStatus ToInfrastructureClientStatus(this ClientStatusInput oth)
    {
        return new ClientStatus()
        {
            ClientStatusName = oth.Name,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}