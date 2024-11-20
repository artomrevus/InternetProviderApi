using InternetProvider.Domain.Entities;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class ClientStatusMappers
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