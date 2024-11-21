using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class ClientStatusMapper
{
    public static ClientStatusResponseDto ToClientStatusResponseDto(this ClientStatusOutput oth)
    {
        return new ClientStatusResponseDto()
        {
            Id = oth.Id,
            Name = oth.Name,
        };
    }
    
    public static ClientStatusInput ToDomainClientStatusInput(this ClientStatusRequestDto oth)
    {
        return new ClientStatusInput()
        {
            Name = oth.Name,
        };
    }
}