using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class ClientStatusMapper(IClientStatus clientStatus) : IMapper<IClientStatus, ClientStatusRequestDto, ClientStatusResponseDto>
{
    public ClientStatusResponseDto ToResponseDto(IClientStatus oth)
    {
        return new ClientStatusResponseDto()
        {
            Id = oth.ClientStatusId,
            Name = oth.ClientStatusName,
        };
    }
    
    public IClientStatus ToEntity(ClientStatusRequestDto oth)
    {
        clientStatus.ClientStatusName = oth.Name;
        
        return clientStatus;
    }
}